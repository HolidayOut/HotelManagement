
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
               DateFormat df = new SimpleDateFormat("dd/MMM/yyyy");
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

    public void insertStay(String username, String checkin, String checkout, int room_id) throws Exception {
        String insertQ = "INSERT INTO STAYS (ID_STAYS, USERNAME, CHECKIN, CHECKOUT, ROOM_ID) VALUES (STAY_SEQ.nextval, ?, ?, ?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(insertQ);
            ps.setString(2, username);
            DateFormat df = new SimpleDateFormat("dd/MMM/yyyy");
            java.util.Date d = df.parse(checkin);
            java.sql.Date dd = new java.sql.Date(d.getTime());
            ps.setDate(3,dd);
            ps.setDate(4, dd);
            ps.setInt(5, room_id);
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void insertStay(Stay stay) {
       
    }
}
