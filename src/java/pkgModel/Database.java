/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

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

    public Account getAccountByUserPw(String user, String pw) {

        String s = "SELECT * FROM ACCOUNTS WHERE username = ? and password = ?";
        Account acc = null;
        
        try {
            PreparedStatement ps = this.createConnection().prepareStatement(s);
            ps.setString(1, user);
            ps.setString(2, pw);
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
}
