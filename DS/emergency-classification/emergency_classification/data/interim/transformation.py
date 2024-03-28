import os

import duckdb
from dotenv import load_dotenv

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
    query = f"""
   CREATE TABLE triagem AS
   SELECT *
   FROM read_csv_auto('{csv_file_path}')
    """
    conn.execute(query)
    print("Table 'triagem' created.")

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