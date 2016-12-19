
/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author John_13
 */
public class Database {

    public static String verbString;
    public static String benutzer;
    public static String passwd;
    static Database db;
    public static Connection verb = null;

    private Database() {

    }

    public Connection createConnection() throws SQLException {
        DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());
        return DriverManager.getConnection(verbString, benutzer, passwd);
    }

    public static Database getInstance() {
        if (null == db) {
            db = new Database();
            verbString = "jdbc:oracle:thin:@212.152.179.117:1521:ora11g";
            benutzer = "d5b20";
            passwd = "d5b";
        }
        return db;
    }

    public Account getAccountByUserPw(Account a) {

        String s = "SELECT * FROM ACCOUNTS WHERE username = ? and password = ?";
        Account acc = null;
        
        try {
            PreparedStatement ps = this.createConnection().prepareStatement(s);
            ps.setString(1, a.getUsername());
            ps.setString(2, a.getPassword());
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                String usern = rs.getString("USERNAME");
                String pass = rs.getString("PASSWORD");
                int rid = rs.getInt("ROLE_ID");
                acc = new Account(usern, pass, rid);
            }
        } catch (Exception p) {
            p.printStackTrace();
        }

        return acc;

    }

    public List<Stay> getAllStays() throws Exception  {
        String s = "Select * from stays";
        List<Stay> temp = null;
        try{
           temp = new ArrayList<Stay>();
           Connection conn = createConnection();
           Statement st = conn.createStatement();
           ResultSet rs = st.executeQuery(s);
           while(rs.next())
           {
               String username = rs.getString(2);
               int id = Integer.valueOf(rs.getString(1));
               DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
               String checkin = df.format(rs.getDate(3));
               String checkout = df.format(rs.getDate(4));
               int rid = Integer.valueOf(rs.getInt(5));
               Stay stay = new Stay(id, username, rid, checkin, checkout);
               temp.add(stay); 
           }
        }
        catch(Exception e)
        {
            throw e;
        }
        return temp;
    }

    public void insertStay(Stay s) throws Exception {
        String insertQ = "INSERT INTO STAYS (ID_STAYS, USERNAME, CHECKIN, CHECKOUT, ROOM_ID) VALUES (STAY_SEQ.nextval, ?, ?, ?, ?)";
        System.out.println(s);
        try {
            PreparedStatement ps = createConnection().prepareStatement(insertQ);
         
            ps.setString(1, s.getUsername());
            DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
            java.util.Date d = df.parse(s.getCheckin());
            java.sql.Date dd = new java.sql.Date(d.getTime());
            ps.setDate(2,dd);
            ps.setDate(3, dd);
            ps.setInt(4, s.getRoomID());
           
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    
    
    public List<Meal> getAllMeals() throws Exception
    {
        String s = "Select * from meals";
        List<Meal> temp = null;
        try{
           temp = new ArrayList<Meal>();
           Connection conn = createConnection();
           Statement st = conn.createStatement();
           ResultSet rs = st.executeQuery(s);
           while(rs.next())
           {
               DateFormat df = new SimpleDateFormat("dd/MMM/yyyy");
               String d = df.format(rs.getDate(2));
               temp.add(new Meal(rs.getString("name"), d));
           }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        return temp;
    }

    public void insertAccount(Account acc) throws Exception {
        String st = "INSERT INTO ACCOUNTS (USERNAME, PASSWORD, ROLE_ID) VALUES(?, ?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
         
            ps.setString(1, acc.getUsername());
            ps.setString(2, acc.getPassword());
            ps.setInt(3, acc.getRole_id());
            
            ps.executeUpdate();
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
                   
}
