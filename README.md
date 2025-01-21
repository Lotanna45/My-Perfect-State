# My Perfect State

## Project Overview
**My Perfect State** is an interactive C# application that connects to a MySQL database to analyze and query demographic, income, education, and marriage statistics for U.S. states. The program offers users a quiz-style interface to explore state statistics and execute predefined SQL queries.

In the United States, many people find it ​difficult to decide the best place to live. ​Despite the abundance of data, people find it ​hard to filter this information to their ​personal preferences. This project examined data correlations between age ​groups, marriage/divorce rates, household ​income, poverty levels, and more, by ​cleaning data, transporting it to MySQL, and ​connecting it to C#. As a result, users can input their data and receive ​feedback on the best US state to live in based ​on their profile.

## Key Features
- **Interactive Quiz:** Users can answer quiz questions about U.S. state statistics.
- **SQL Query Execution:** Run detailed queries on population, income, education, and marriage data.
- **Database Integration:** Connects to MySQL for real-time data querying.
- **Predefined Queries:** Includes 13 SQL queries to retrieve insightful statistical information about U.S. states.

## Prerequisites
1. Install .NET Core SDK.
2. Set up MySQL Server with the required schema and data.
3. Install the MySQL Connector for .NET:
   ```bash
   dotnet add package MySqlConnector
   ```

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/my-perfect-state.git
   ```
2. Navigate to the project directory:
   ```bash
   cd my-perfect-state
   ```
3. Build the application:
   ```bash
   dotnet build
   ```

## Usage
1. Run the application:
   ```bash
   dotnet run
   ```
2. Follow the prompts to:
   - Take a quiz about U.S. state statistics.
   - Select and execute predefined SQL queries.

## Key Algorithms and Structures
- **Data Structures:**
  - `List<string>` and `List<int>`: Store quiz questions and IDs.
  - `MySqlCommand` and `MySqlDataReader`: Execute and retrieve results from SQL queries.

- **Key Functions:**
  - `makeQuestions()`: Populates quiz questions.
  - `setUp(string sql)`: Establishes a MySQL database connection and prepares an SQL command.
  - `questionsFunc()`: Manages user interaction for quiz questions.

- **SQL Queries:**
  1. States with household size ≥2.
  2. Top 10 states with high school graduates >30%.
  3. Top 3 states with the largest marriage-divorce percentage differences.
  4. States with income below the national average.
  5. Top 5 states with high income and marriage rates.
  6. Smallest population states with high poverty levels.
  7. Worst states by income, divorce, and poverty percentages.
  8. Race with the highest mean income and marital status distribution.
  9. Household income and per-person income statistics.
  10. Income differences based on educational attainment.
  11. States with high graduate and bachelor's degree percentages.
  12. Poverty statistics for specific states.
  13. Average income across all races.

## Configuration
1. Update the `myConnectionString` variable with your MySQL server credentials:
   ```csharp
   static string myConnectionString = "server=127.0.0.1;uid=root;pwd=YOUR_PASSWORD;database=new_state_stats";
   ```
2. Ensure your MySQL database is populated with the necessary tables and data for the queries.

## Outputs
- Quiz feedback (correct/incorrect answers).
- Query results printed in a formatted table.

Example Output:
```
name_of_region           | Total Population      | HouseholdIncome        | AverageHouseholdSize
-------------------------|-----------------------|------------------------|----------------------
Utah                    | 3,205,958            | 85,000                | 3.1
...
```

## Code Structure
- `Program.cs`: Main program logic and SQL query execution.
- **SQL Queries:** Predefined in individual methods for modularity and reusability.

## Author
- **Lotanna Akukwe** 
