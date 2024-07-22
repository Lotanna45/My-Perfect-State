///////////////////////////////////////////////////
// Authored by: Lotanna Akukwe
// My Perfect State
// Date: 19th of May, 2023
//////////////////////////////////////////////////
using System;
using MySqlConnector;

// dotnet new console -- create new C# project
// dotnet add package MySqlConnector -- add the MySQL Connector package
// dotnet build -- build the application
// bin/Debug/net7.0/tutorial

namespace Downloads
{
    class Program
    {       
        static List<string> stringList = new List<string>(); //Creates a new list of questions to ask the user
        static List<int> intList = new List<int>();  //Creates a new list of integers that represent the questions being asked

        //sets up the quize questions ID
           static  bool In1 = false;
           static bool In2 = false;
            static bool In3 = false;
            static bool In4 = false;
            static bool In5 = false;

        //Populates the questions list
        static void makeQuestions(){
        stringList.Add("(1) What state is statistically best to move to for income + marriage? \n");
        stringList.Add("(2) Which state has the highest divorce rate? \n");
        stringList.Add("(3) What state is the only state that has an average household size of 3 or more? \n");
        stringList.Add("(4) Which state has the highest poverty estimate? \n");
        stringList.Add("(5) Is Connecticut one of the cities with about 20% of their population having a graduate's degree? Answer yes or no. \n");
        } 

        //Establishes the connection with MySql Workbench
        static string myConnectionString = "server=127.0.0.1;uid=root;pwd=Nwakalor!1;database=new_state_stats";        
        static int limit = 0;
        static MySqlConnection conn;
        static MySqlCommand setUp(string sql){
            conn = new MySqlConnection(); 
            conn.ConnectionString = myConnectionString; 
             conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            return cmd;
        }

        /*
        static void demo (){
            
          //  string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=northwind";
            string sql = "SELECT C.`Company`, E.`Last Name` " +
            "FROM Customers C, Employees E, Orders O " +
            "WHERE E.ID=O.`Employee ID` AND C.ID=O.`Customer ID` AND " +
            "O.`Shipping Fee` < @shipping_fee " +
            "ORDER BY O.`Shipping Fee`";  
            double maxfee = 20;
            try {
                 // this connects to the local host and user part
                
                 MySqlCommand cmd = setUp(sql);
               
              //  sqlPerameter(sql);
               // MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@shipping_fee", maxfee); // this relates to the double max fee in that
                // the double max fee is what is replaccing the shipping fee in the query
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine("Company" + ": " + "Last Name");
                while (rdr.Read()) { // this reas through and the data like reading through a file
                    Console.WriteLine(rdr["Company"] + ": " + rdr["Last Name"]);
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }
        */

        //First SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_01(){
           // MySqlConnection conn;
            string myConnectionString = "server=127.0.0.1;uid=root;pwd=mySqu1rrel*;database=new_state_stats";

            //SQL query
            string sql_EX05_01 = "SELECT  rt.name_of_region, ps.`Total Population`, ibs.HouseholdIncome, hs.AverageHouseholdSize  " +
            "FROM population_state as ps Join income_by_state as ibs on ps.RegionID = ibs.RegionID " +
            "Join householdsize_state as hs on hs.RegionID = ps.RegionID " + 
            "Join region_table as rt on rt.ID = ps.RegionID " +
            " where hs.AverageHouseholdSize >= 2 ";

            //Try with a catch exception
            try {
               MySqlCommand cmd = setUp(sql_EX05_01); 
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine(TPSC("name_of_region") + "| " + TPSC("Total Population") + "| " + TPSC("HouseholdIncome")+ "|" + TPSC("AverageHouseholdSize")); //Header for the Sql result
                limit = 0;
                while ((rdr.Read())) { // this reas through and the data like reading through a file
                    Console.WriteLine(TPOC(rdr["name_of_region"]) + "| " + TPOC(rdr["Total Population"]) + "| " + TPOC(rdr["HouseholdIncome"]) + "| " + TPOC(rdr["AverageHouseholdSize"])); //Results of the sql query
                limit ++;
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }
        
        //Second SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_02(){
            //SQL query
            string sql_EX05_02 = "SELECT rt.name_of_region, ibs.HouseholdIncome, p.`Poverty_Percent_All Ages 2022`, es.High_school_graduate " + 
            "FROM poverty_2022 as p Join income_by_state as ibs on p.RegionID = ibs.RegionID " +
            "join eductation_state as es on p.RegionID = es.region_ID " +
            "join region_table as rt on rt.ID = p.RegionID " +
            "where es.High_school_graduate > 30 " +
            "ORDER BY p.`Poverty_Percent_All Ages 2022` DESC " +
            "LIMIT 10";

            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_02);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                Console.WriteLine(TPSC("name_of_region") + "| " + TPSC("HouseholdIncome") + "| " + TPSC("Poverty_Percent_All Ages 2022") + "| " + TPSC("High_school_graduate")); //Header for the query results
                limit = 0;
                while ((rdr.Read())) { // this reas through and the data like reading through a file
                    Console.WriteLine(TPOC(rdr["name_of_region"]) + "| " + TPOC(rdr["HouseholdIncome"]) + "| " + TPOC(rdr["Poverty_Percent_All Ages 2022"]) + "| " + TPOC(rdr["High_school_graduate"])); //Prints the results of the query
                limit++;
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }

        }

        //Third SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_03(){
            //Sql query
            string sql_EX05_03 = "SELECT rt.name_of_region, ms.Married, ms.Divorced "+
            " FROM marriagestats_state as ms join region_table as rt on ms.RegionID = rt.ID " +
            " ORDER BY ABS(ms.Married - ms.Divorced) DESC ";

            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
               limit = 0;
                Console.WriteLine(TPSC("name_of_region") + "| " + TPSC("Married") + "| " + TPSC("Divorced")); //Header for the query results
                
                while ((rdr.Read())&& (limit < 3)) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["name_of_region"]) + "| " + TPOC(rdr["Married"])+ "| " + TPOC(rdr["Divorced"])); //Prints the results of the query
                limit++;        
            }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Fourth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_04(){

            //Sql query
            string sql_EX05_03 = "SELECT isb.HouseholdIncome, rt.name_of_region "+
            " FROM income_by_state as isb join region_table as rt on rt.ID = isb.RegionID, " +
            " (select avg(`Median income $`) as income from householdsize_income_usa) as avgincome " +
            " Where isb.HouseholdIncome < avgincome.income " +
            " order by isb.HouseholdIncome desc ";

            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
               limit = 0;
                Console.WriteLine(TPSC("HouseholdIncome") + "| " + TPSC("name_of_region") ); //Prints the header for the sql results
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["HouseholdIncome"]) + "| " + TPOC(rdr["name_of_region"])); //Prints the results for the sql query
                limit++;        
            }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Fifth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_05(){
            //Sql query
            string sql_EX05_03 = " SELECT rt.name_of_region, ibs.HouseholdIncome, ms.Married "+
            " FROM income_by_state as ibs join marriagestats_state as ms on ibs.RegionID = ms.RegionID " +
            " Join region_table as rt on rt.ID = ibs.RegionID " +
            " ORDER BY ms.Married DESC, ibs.HouseholdIncome DESC " +
            " LIMIT 5 ";

            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
               limit = 0;
                Console.WriteLine(TPSC("name_of_region")+ "| " + TPSC("HouseholdIncome") + "| " + TPSC("Married")); //Prints the header for the query results
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["name_of_region"]) + "| " + TPOC(rdr["HouseholdIncome"]) + "| " + TPOC(rdr["Married"])); //Prints the results of the query
                limit++;        
            }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Sixth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_06(){
            //Sql query
            string sql_EX05_03 = " SELECT subquery.name_of_region, subquery.`Total Population`, subquery.max_poverty_percent "+
            " FROM ( " +
            " SELECT rt.name_of_region, ps.`Total Population`, " +
            "  (SELECT MAX(`Poverty_Percent_All Ages 2022`) FROM poverty_2022 WHERE RegionID = ps.RegionID) AS max_poverty_percent " +
            " FROM population_state ps " +
            " JOIN region_table rt ON rt.ID = ps.RegionID " +
            "ORDER BY `Total Population` ASC " +
            " LIMIT 10 " +
            " ) AS subquery " +
            "ORDER BY subquery.max_poverty_percent DESC " +
            "LIMIT 1 ";

            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
                limit = 0;
                Console.WriteLine(TPSC("name_of_region") + ": " + TPSC("Total Population") + ": " + TPSC("max_poverty_percent")); //Prints the header for the query results
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["name_of_region"]) + ": " + TPOC(rdr["Total Population"]) + ": " + TPOC(rdr["max_poverty_percent"])); //Prints the results of the query
                    limit++;        
                }
                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Seventh SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_07(){
            //sql query
            string sql_EX05_03 = " SELECT rt.name_of_region, ibs.HouseholdIncome, ROUND((p2.`Poverty_Percent_All Ages 2022`/avgPoverty.Poverty) * 100 -100, 2 ) as `poverty % more compared to avg`, ROUND((ms.Divorced/avgDivorce.divorces) *100 -100, 2 ) as `divorce % more compared to avg` "+
            " FROM income_by_state ibs join poverty_2022 p2 on ibs.RegionID = p2.RegionID " +
            " Join region_table as rt on rt.ID = ibs.RegionID " +
            "  Join marriagestats_state as ms on ms.RegionID = ibs.RegionID, " +
            " (select avg(p2.`Poverty_Percent_All Ages 2022`) as Poverty from poverty_2022 p2) as avgPoverty, " + 
            " (select avg(ms.Divorced) as divorces from marriagestats_state ms) as avgDivorce " +
            " where  p2.`Poverty_Percent_All Ages 2022` >  avgPoverty.Poverty " +
            " ORDER By ibs.HouseholdIncome ASC ";

            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("name_of_region")  + "| " + TPSC("HouseholdIncome" )+ "| " + TPSC("pov % more comprd 2 avg" ) + "| " + TPSC("div % more comprd 2 avg")); //Prints the header for the query results
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                // it takes in an object, converts to string, converts into PADright string
                Console.WriteLine(TPOC(rdr["name_of_region"])  + "| " + TPOC(rdr["HouseholdIncome"]) + "| " + TPOC(rdr["poverty % more compared to avg"])  + "| " + TPOC(rdr["divorce % more compared to avg"]) ); //Prints the results of the sql query
            }
                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Eight SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_08(){
            //sql query
            string sql_EX05_03 = "  Select R.Race, aimu.type, aimu.total, aimu.`Single (never married)`, aimu.married, aimu.Widowed, aimu.Divorced"+
            " From race_table as R Join allrace_income_marriage_usa as aimu on R.ID = aimu.RaceID " +
            " Where aimu.total = (Select Max(aimu.total) From allrace_income_marriage_usa as aimu Where type = \"Mean income (dollars)\")";
            
            //Try with a catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("Race")  + "| " + TPSC("type" )+ "| " + TPSC("total" ) + "| " + TPSC("Single (never married)") + "| " + TPSC("married") + "| " + TPSC("Widowed") + "| " + TPSC("Divorced")); //Prints the header for the query results
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["Race"])  + "| " + TPOC(rdr["type"]) + "| " + TPOC(rdr["total"])  + "| " + TPOC(rdr["Single (never married)"]) + "| " + TPOC(rdr["married"]) + "| " + TPOC(rdr["Widowed"])+ "| " + TPOC(rdr["Divorced"]) ); //Prints the results of the sql query
                }
                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Ninth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_09(){

            //Sql query
            string sql_EX05_03 = "  Select hiu.`household size`, hiu.`Mean income $`, hiu.`Income per family member $`, "+
            " (Select Avg(hiu.`Mean income $`)  from householdsize_income_usa as hiu   where hiu.`household size` IN ('Two people', 'Three people', 'Four people')) as avgmean " +
            " From householdsize_income_usa as hiu  " +
            "  WHERE hiu.`household size` IN ('Two people', 'Three people', 'Four people')";
            
            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("household size")  + "| " + TPSC("Mean income $" )+ "| " + TPSC("Income per family member $" ) + "| " + TPSC("avgmean" )); //Prints the header for the results of the query
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.

                    Console.WriteLine(TPOC(rdr["household size"])  + "| " + TPOC(rdr["Mean income $"]) + "| " + TPOC(rdr["Income per family member $"])  + "| " + TPOC(rdr["avgmean"])); //Prints the results of the sql query
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }
        
        //Tenth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_10(){

            //Sql query
            string sql_EX05_03 = " Select ( Select (Select eiu.`Median income Value   (Dol.)` as Bach  "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Bachelors_degree\") - "
            + " (Select eiu.`Median income Value   (Dol.)` as Bach "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Associates_degree\")) as Bach_Asso_Diff, "

            + " (Select (Select eiu.`Median income Value   (Dol.)` as Grad "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Graduate_or_professional_degree\") - "
            + " (Select eiu.`Median income Value   (Dol.)` as Bach "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Bachelors_degree\")) as Grad_Bach_Diff, "

            + " (Select (Select eiu.`Median income Value   (Dol.)` as Grad "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Graduate_or_professional_degree\") - "
            + " (Select eiu.`Median income Value   (Dol.)` as Asso "
            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Where en.Name = \"Associates_degree\")) as Grad_Asso_Diff " 

            + " From equcation_income_usa as eiu join education_nametable as en on eiu.education_ID = en.ID "
            + " Limit 1 ";
            
            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("Bach_Asso_Diff")  + "| " + TPSC("Grad_Bach_Diff" )+ "| " + TPSC("Grad_Asso_Diff" )); //Prints the headers the query results 
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.
                    Console.WriteLine(TPOC(rdr["Bach_Asso_Diff"])  + "| " + TPOC(rdr["Grad_Bach_Diff"]) + "| " + TPOC(rdr["Grad_Asso_Diff"])); //Prints the results of the sql query
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Eleventh SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_11(){

            //sql query
            string sql_EX05_03 = "  SELECT en.`name_of_region` "+
            " FROM eductation_state as es join region_table as en on es.region_ID = en.ID " +
            " WHERE es.`Graduate_or_professional_degree` >= 10 and es.`Bachelors_degree` >= 20 ";
            
            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("name_of_region") ); //Prints the header for the query results
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.

                    Console.WriteLine(TPOC(rdr["name_of_region"]) ); //Prints the results for the sql query
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }
        
        //Twelfth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_12(){

            //sql query
            string sql_EX05_03 = "  SELECT p2.`Poverty_Estimate_ All Ages 2022` as Poverty_estimate, rt.name_of_region "+
            " FROM poverty_2022 as p2 join region_table as rt on p2.RegionID = rt.ID " +
            " WHERE rt.`name_of_region` IN ('Washington', 'Utah', 'Nebraska', 'Hawaii') ";
            
            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("Poverty_estimate")  + "| " + TPSC("name_of_region" )); //Prints the headers for the query results
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.

                    Console.WriteLine(TPOC(rdr["Poverty_estimate"])  + "| " + TPOC(rdr["name_of_region"])); //Prints the results of the sql query
                }
                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Thirteenth SQL query 
        //No parameters 
        //Void function that runs the sql query and gets the results
        static void EX0F_13(){
            //Sql query
            string sql_EX05_03 = "  SELECT avg(aimu.total) as Average_Income_For_All "+
            " FROM allrace_income_marriage_usa as aimu " +
            " WHERE aimu.type = \"total\" ";
            
            //Try with catch exception
            try {
                MySqlCommand cmd = setUp(sql_EX05_03);
                MySqlDataReader rdr = cmd.ExecuteReader(); // executes the sql code
             
                Console.WriteLine(TPSC("average_Income_For_All"));// Prints the header for the query results
                Console.WriteLine();
                while ((rdr.Read())) { // this reas through and the data like reading through a file// this should get rid of SQL Injection attacks.

                    Console.WriteLine(TPOC(rdr["average_Income_For_All"])); //Prints the results of the sql query
                }

                rdr.Close();
            }
            catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
            }
        }

        //Sets the width by converting it into a string
        //Arg: an object (in this case the object is a string like the column data)
        //returns the object with set widths 
       static string TPOC(object needsToConvert){ // ToPadObjectConverter
        int maxWidth = 25;
        string temp = needsToConvert.ToString();
        string FormatTemp = temp.PadRight(maxWidth);
        return FormatTemp;
        }

        //Sets the width by converting it into a string
        //Arg: a string(in this case the object is a string like the column names)
        //returns the object with set widths
        static string TPSC(string needsToConvert){ // ToPadStringConverter
        int maxWidth = 25;
        string temp = needsToConvert.ToString();
        string FormatTemp = temp.PadRight(maxWidth);
        return FormatTemp;
        }

        //Quiz function that shows the list of quiz questions and manages how the user interacts with the program
        static void questionsFunc(){
            string num1 = "1";
            string num2 = "2";
            string num3 = "3";
            string num4 = "4";
            string num5 = "5";
 
            Console.WriteLine("\n\n\n\n Which question do you want? (pick a number)\n\n");
            string selectedString = stringList[1];
            int num = 5;
            //Lists all the quiz questions available 
            for (int i = 0; i < num; i++){
                Console.WriteLine("(" + i + " ) " + stringList[i]);                            
            }
              string answer = Console.ReadLine(); //User enters which quiz question they want to answer

              /*If the number entered by the user is matches any of the question Id's, the user will have an opportunity to answer the question
                If the question was previously answered, they wouldn't be able to answer that question again.
                Or, if they got the question wrong, they'd have to try the quetion again next time
              */
              if (answer == num1){
                 if (In1 == false){
                 Console.WriteLine("\n whats the answer? \n");
                 string sec_answer = Console.ReadLine();
                 if (sec_answer.ToLower() == "utah")
                     Console.WriteLine("\n Correct!\n"); 
                     In1 = true;  
                 }else if (In1){
                    Console.WriteLine("\nYou already got this question correct\n");    
                 }else {
                    Console.WriteLine("\n Hmmm... try again\n");    
                 }
                
              } if (answer == num2){
                 if (In2 == false){
                 Console.WriteLine("\n whats the answer? \n");
                 string sec_answer = Console.ReadLine();
                 if (sec_answer.ToLower() == "nevada")
                     Console.WriteLine("\n Correct!\n");  
                     In2 = true;  
                 }else if (In2){
                    Console.WriteLine("\nYou already got this question correct\n");    
                 }else{
                     Console.WriteLine("\n Not quite right...\n");    
                 }
              } if (answer == num3){
                if (In3 == false){
                 Console.WriteLine("\n whats the answer? \n");
                 string sec_answer = Console.ReadLine();
                 if (sec_answer.ToLower() == "utah")
                     Console.WriteLine("\n Correct!\n"); 
                     In3 = true;     
                 }else if (In3){
                    Console.WriteLine("\nYou already got this question correct\n");    
                 }else{
                     Console.WriteLine("\n wrong answer :( \n");    
                 }
              } if (answer == num4){
                if (In4 == false){
                 Console.WriteLine("\n whats the answer? \n");
                 string sec_answer = Console.ReadLine();
                 if (sec_answer.ToLower() == "washington")
                     Console.WriteLine("\n Correct!\n"); 
                     In4 = true;     
                 }else if (In4){
                    Console.WriteLine("\nYou already got this question correct\n");    
                 }else{
                     Console.WriteLine("\n wrong answer :( \n");    
                 }
              } if (answer == num5){
                if (In5 == false){
                 Console.WriteLine("\n whats the answer? \n");
                 string sec_answer = Console.ReadLine();
                 if (sec_answer.ToLower() == "no")
                     Console.WriteLine("\n Correct!\n"); 
                     In5 = true;     
                 }else if (In5){
                    Console.WriteLine("\nYou already got this question correct\n");    
                 }else{
                     Console.WriteLine("\n wrong answer :( \n");    
                 }
              }     
        }

        static void Main(string[] args)
        {
          // demo();  
           makeQuestions(); //Calls the funtion that populates the quiz list

        //Asks the user if they are ready to take the quiz
          for (int i = 0; i < 10; i++){
          Console.WriteLine("\nAre you ready to answer a question? (Y/n) \n" );
           string answer = Console.ReadLine();
           if (answer == "Y"){
            questionsFunc();
           }
        //Shows the user the list of queries they can pick from.
          Console.WriteLine("\nPICK A QUERY to execute, a number between 1-10:\n\n" 
          + "1: Retrieve the US state, population, income, and average household size that have a household size of 2 or more. \n\n" 
          + "2: Retrieve the states, avg income, and poverty percent level of the top 10 US states with a high school educational level of 30% or more.\n\n"
          + "3: Retrieve the top 3 divorced and married percent for each US state with the biggest difference between marriage being high and divorce being low.\n\n"
          + "4: Retrieve the income and the name of states with households who live below the average of the usa income.\n\n"
          + "5: The top 5 ideal states that have a high avg income level, with a high probability of Married status.\n\n"
          + "6: A state that has one of the 10 smallest populations and has a high poverty level.\n\n"
          + "7: the worst state statistically ordered off by lowest income, and in what percent of each state is its divorce rate and poverty rate over or below the average of the us. \n\n"
          + "8: the race has the highest mean income and the total size/number of people in the group that are married, single, widowed and divorced. \n\n" 
          + "9: Retrieve the mean income and income per person for households with a size of 4 or less, as well as the average income for these household sizes. \n\n"
          + "10: Retrieve the difference in income between an associate's, a bachelor's, and a graduate's degree.  \n\n"
          + "11: Get the states that have a graduate_degree percentage of 10% or more and a bachelors percentage of 20% or more. \n\n"
          + "12: Get the poverty estimates and state names for Washington State, Utah, Hawaii, and Nebraska. \n\n"
          + "13: Retrieve the average total income for all races. \n\n");

        //Gets the query id number that the user wishes to run
         string num; 
         num = Console.ReadLine();
                /*Identify the query by the Id number,
                    If it's a match then, the query function will be called; establishing an sql connection,
                    running a query, and printing the results of that query
                */
                if( num == "1"){
                Console.WriteLine("\nEX_01");
                EX0F_01(); 
                }else if(num == "2"){
                Console.WriteLine("\nEX_02");
                EX0F_02();
                }else if(num == "3"){
                Console.WriteLine("\nEX_03");
                EX0F_03(); // done   
                }else if(num == "4"){
                Console.WriteLine("\nEX_04");
                EX0F_04(); // done                    
                }else if(num == "5"){
                Console.WriteLine("\nEX_05");
                EX0F_05(); // done                    
                }else if(num == "6"){
                Console.WriteLine("\nEX_06");
                EX0F_06(); // done                    
                }else if(num == "7"){
                Console.WriteLine("\nEX_07");
                EX0F_07(); // done                    
                }else if(num == "8"){
                Console.WriteLine("\nEX_08");
                EX0F_08();                   
                }else if(num == "9"){
                Console.WriteLine("\nEX_09");
                EX0F_09();                    
                }else if(num == "10"){
                Console.WriteLine("\nEX_10");
                EX0F_10();                    
                }else if(num == "11"){
                Console.WriteLine("\nEX_11");
                EX0F_11();                    
                }else if(num == "12"){
                Console.WriteLine("\nEX_12");
                EX0F_12();                    
                }else if(num == "13"){
                Console.WriteLine("\nEX_13");
                EX0F_13();                    
                }
         }
        }
    }
}
