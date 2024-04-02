import os

import duckdb
from deep_translator import GoogleTranslator
from dotenv import load_dotenv


def snake_case(column_name):
    """
    Convert a string to snake case.

    Args:
        column_name (str): The string to be converted.

    Returns:
        str: The converted string in snake case.
    """
    return column_name.lower().replace(" ", "_").replace("-", "_")


def translate_column(column_name, new_column, table):
    """
    Translates the values in a specified column of a table using Google
    Translate API and updates a new column with the translated values.
    """
    translator = GoogleTranslator(source="en", target="pt")

    # Adjusted comment to SQL style
    query = f"""SELECT {column_name}
                FROM {table}"""

    result = conn.execute(query).fetchall()

    for row in result:
        text = row[0]
        try:
            translation = translator.translate(text)
            # update the row with the translation
            update_query = f"""UPDATE {table} SET {new_column} = ? 
                                        WHERE {column_name} = ?;"""
            # Ensure the correct table name is used
            # execute the query
            conn.execute(update_query, (translation, text))
        except Exception as e:
            print(
                f"Error translating text '{text}' in column '{column_name}'. Error: {e}"
            )


# load .env file
env_file_path = os.path.join(os.path.dirname(__file__), "..", "..", ".env")
load_dotenv(dotenv_path=env_file_path)

path = os.getenv("HOME_PATH")

# connect to database
conn = duckdb.connect(os.path.join(path, "data/interim/interim.db"), read_only=False)

# check if the table exists
table_exists = conn.execute(
    "SELECT * FROM information_schema.tables WHERE table_name = 'triagem'"
).fetchall()

if table_exists:
    print("Table 'triagem' already exists. Dropping and recreating it.")
    conn.execute("DROP TABLE triagem")

# CSV file path
csv_file_path = os.path.join(path, "data/raw/utf8_data.csv")

try:
    # create a table with csv data
    query = f"""CREATE TABLE triagem AS
                SELECT *
                FROM read_csv_auto('{csv_file_path}')
            """

    conn.execute(query)

    # rename columns to snake case
    columns_info = conn.execute("PRAGMA table_info('triagem')").fetchall()
    for column in columns_info:
        original_column_name = column[1]
        # check if the column name is a reserved word
        if original_column_name.lower() == "group":
            new_column_name = "group_"
        else:
            new_column_name = snake_case(original_column_name)
        if (
            new_column_name != original_column_name
        ):  # check if the column name is already in snake case
            rename_query = f'ALTER TABLE triagem RENAME COLUMN "{original_column_name}" TO {new_column_name};'
            conn.execute(rename_query)

    print("Table 'triagem' created and columns renamed.")

    # add new columns
    conn.execute("ALTER TABLE triagem ADD COLUMN chief_complain_pt TEXT;")
    conn.execute("ALTER TABLE triagem ADD COLUMN diagnosis_in_ed_pt TEXT;")

    # translate columns
    translate_column("chief_complain", "chief_complain_pt", "triagem")
    translate_column("diagnosis_in_ed", "diagnosis_in_ed_pt", "triagem")

    # commit transaction
    conn.commit()

    try:
        result = conn.execute("SELECT * FROM triagem LIMIT 10")
        print(result.fetchdf())
    except Exception as e:
        print(f"An error occurred when querying the table: {e}")

except Exception as e:
    # rollback transaction
    conn.rollback()
    print(f"An error occurred: {e}")

finally:
    # close connection
    conn.close()
    print("Connection closed.")
