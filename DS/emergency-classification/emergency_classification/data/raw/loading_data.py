import os
import sys

import pandas as pd
from dotenv import load_dotenv

# load .env file
env_file_path = os.path.join(os.path.dirname(__file__), "..", "..", ".env")
load_dotenv(dotenv_path=env_file_path)

path = os.getenv("HOME_PATH")
full_path = os.path.join(path, 'data/external/data.csv')
new_path = os.path.join(path, 'data/raw/', 'utf8_data.csv')

# verify if the files exists
if not os.path.exists(full_path):
    print("The file does not exist.")
    sys.exit()

if os.path.exists(new_path):
    print(f"The file located in {new_path} already exists.")
    sys.exit()
    
try:
    # try reading with utf-8 encoding and skip bad lines
    df = pd.read_csv(full_path, sep=';', encoding='utf-8', on_bad_lines='skip', engine='python')
except UnicodeDecodeError:
    # if there's an encoding error, try reading with ISO-8859-1 encoding
    df = pd.read_csv(full_path, sep=';', encoding='ISO-8859-1', on_bad_lines='skip', engine='python')

# save the DataFrame in utf-8 encoding to a new CSV file
df.to_csv(new_path, index=False, encoding='utf-8')

print("CSV file has been processed and saved to:", new_path)
