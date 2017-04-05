
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
            //212.152.179.117
            verbString = "jdbc:oracle:thin:@aphrodite4:1521:ora11g";
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

    public List<Stay> getAllStays() throws Exception {
        String s = "Select * from stays";
        List<Stay> temp = null;
        try {
            temp = new ArrayList<Stay>();
            Connection conn = createConnection();
            Statement st = conn.createStatement();
            ResultSet rs = st.executeQuery(s);
            while (rs.next()) {
                String username = rs.getString(2);
                int id = Integer.valueOf(rs.getString(1));
                DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
                String checkin = df.format(rs.getDate(3));
                String checkout = df.format(rs.getDate(4));
                int rid = Integer.valueOf(rs.getInt(5));
                Stay stay = new Stay(id, username, rid, checkin, checkout);
                temp.add(stay);
            }
        } catch (Exception e) {
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
            ps.setDate(2, dd);
            ps.setDate(3, dd);
            ps.setInt(4, s.getRoomID());

            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public List<Meal> getAllMeals() throws Exception {
        String s = "Select * from meals";
        List<Meal> temp = null;
        try {
            temp = new ArrayList<Meal>();
            Connection conn = createConnection();
            Statement st = conn.createStatement();
            ResultSet rs = st.executeQuery(s);
            while (rs.next()) {
                int id_meal = rs.getInt(1);
                int meal_type = rs.getInt(2);
                String mealName = rs.getString(3);
                double p = rs.getDouble(4);

                Meal m = new Meal();
                m.setMealType(meal_type);
                m.setName(mealName);
                m.setPrice(p);
                m.setTime("20.Apr.2016");
                m.setId(id_meal);
                temp.add(m);
            }
        } catch (Exception ex) {
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
        } catch (Exception ex) {
            throw ex;
        }

    }

    public void insertGuest(Guest content) throws Exception {
        String st = "INSERT INTO HOTELGUESTS (NAME, USERNAME) VALUES(?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);

            ps.setString(1, content.getName());
            ps.setString(2, content.getUsername());

            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void updateRoom(Room r) throws Exception {
        String st = "UPDATE ROOMS SET ROOMSIZE = ?, ROOMPRICE = ? WHERE ID_ROOM = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);

            ps.setInt(1, r.getRoomsize());
            ps.setInt(2, r.getRoomprize());
            ps.setInt(3, r.getId());

            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }

    }

    public void deleteRoom(int id) throws Exception {
        String st = "DELETE FROM ROOMS WHERE ID_ROOM = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (Exception ex) {
            throw new Exception("Wird von einem Gast belegt");
        }
    }

    public void insertRoom(Room r) throws Exception {
        String st = "INSERT INTO ROOMS VALUES(?, ?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, r.getId());
            ps.setInt(2, r.getRoomsize());
            ps.setInt(3, r.getRoomprize());
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public Room getRoomByID(int id) throws Exception {
        String st = "SELECT * FROM ROOMS WHERE ID_ROOM = ?";
        Room r = null;
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, id);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                int _id = rs.getInt(1);
                int size = rs.getInt(2);
                int prize = rs.getInt(3);
                r = new Room(id, size, prize);
            }
        } catch (Exception ex) {
            throw ex;
        }

        return r;
    }

    public List<Room> getAllRooms() throws Exception {
        String st = "SELECT * FROM ROOMS ORDER BY ID_ROOM";
        List<Room> temp = null;
        try {
            temp = new ArrayList<Room>();
            Statement s = createConnection().createStatement();
            ResultSet rs = s.executeQuery(st);
            while (rs.next()) {
                int _id = rs.getInt(1);
                int size = rs.getInt(2);
                int prize = rs.getInt(3);
                Room r = new Room(_id, size, prize);
                temp.add(r);
            }
        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public Role getRoleByUsername(String username) throws Exception {
        String st = "SELECT ID_Role, Rolename, ID_Permission, Permissionname FROM Accounts "
                       + "INNER JOIN Roles ON Accounts.Role_ID = Roles.ID_Role "
                       + "INNER JOIN RoleHasPermissions ON RoleHasPermissions.KEY_ROLE = Roles.ID_Role "
                       + "INNER JOIN permissions ON ROLEHASPERMISSIONS.KEY_PERMISSIONS = Roles.ID_Role "
                       + "WHERE username =?";
        Role r = new Role();
        boolean isFirst = true;
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setString(1, username);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id_role = rs.getInt(1);
                String role_name = rs.getString(2);
                int id_perm = rs.getInt(3);
                String perm_name = rs.getString(4);

                if (isFirst) {
                    r.setID_Role((id_role));
                    r.setName(role_name);
                    r.getCollPermissions().add(new Permission(id_perm, perm_name));
                    isFirst = false;
                } else {
                    r.getCollPermissions().add(new Permission(id_perm, perm_name));
                }

            }
        } catch (Exception ex) {
            throw ex;
        }
        return r;
    }

    public List<Role> getAllRoles() throws Exception {
        String s = "SELECT * FROM ROLES";
        List<Role> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Role>();
            while (rs.next()) {
                Role r = new Role();
                int id_role = rs.getInt(1);
                String role_name = rs.getString(2);
                r = new Role(id_role, role_name);
                temp.add(r);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public List<Permission> getAllPermissionsByRole(int ID_Role) throws Exception {
        String commandText = "SELECT ID_Permission, Permissionname "
                       + "FROM rolehaspermissions "
                       + "INNER JOIN roles ON roles.ID_ROLE = rolehaspermissions.KEY_ROLE "
                       + "INNER JOIN permissions ON permissions.ID_PERMISSION = rolehaspermissions.KEY_PERMISSIONS "
                       + "WHERE ID_ROLE = " + ID_Role;
        List<Permission> temp = null;
        try {
            temp = new ArrayList<Permission>();
            PreparedStatement ps = createConnection().prepareStatement(commandText);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id_perm = rs.getInt(1);
                String perm_name = rs.getString(2);
                Permission p = new Permission(id_perm, perm_name);
                temp.add(p);
            }
        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public void insertRole(Role r) throws Exception {
        String s = "INSERT INTO ROLES VALUES(sequenceIncrementIDRole.nextVal, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setString(1, r.getName());
            ps.executeQuery();
        } catch (Exception e) {
            throw e;
        }
    }

    public void removeRoleById(int id_role) throws Exception {
        String s = "DELETE FROM ROLES WHERE ID_ROLE = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setInt(1, id_role);
            ps.executeUpdate();
        } catch (Exception e) {
            throw e;
        }
    }

    public List<Permission> getAllPermissions() throws Exception {
        String s = "SELECT * FROM PERMISSIONS";
        List<Permission> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Permission>();
            while (rs.next()) {
                Permission r = new Permission();
                int id_perm = rs.getInt(1);
                String perm_name = rs.getString(2);
                r = new Permission(id_perm, perm_name);
                temp.add(r);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public List<Guest> getAllGuests() throws Exception {
        String s = "SELECT * FROM HOTELGUESTS";
        List<Guest> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Guest>();
            while (rs.next()) {
                Guest r = new Guest();
                String name = rs.getString(1);
                String username = rs.getString(2);
                r = new Guest(name, username);
                temp.add(r);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public Role getRoleByID(int id) throws Exception {
        String s = "SELECT * FROM ROLES WHERE ID_ROLE = ?";
        Role r = null;
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setInt(1, id);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                int id_role = rs.getInt(1);
                String name = rs.getString(2);
                r = new Role(id_role, name);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return r;
    }

    public void removePermissionsFromRole(Wrapper w) throws Exception {
        String s = "DELETE FROM RoleHasPermissions WHERE key_Role = ? AND key_Permissions = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setInt(1, w.getId_role());
            ps.setInt(2, w.getId_permission());
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void addPermissionsToRole(Wrapper w) throws Exception {
        String s = "INSERT INTO RoleHasPermissions (key_role, key_permissions) VALUES (?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setInt(1, w.getId_role());
            ps.setInt(2, w.getId_permission());
            ps.executeUpdate();
        } catch (Exception e) {
            throw e;
        }
    }

    public List<Employee> getEmployees() throws Exception {
        String s = "SELECT * FROM EMPLOYEES inner join accounts on employees.username = accounts.username inner join roles on roles.id_role = accounts.role_id";
        List<Employee> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Employee>();
            while (rs.next()) {
                Employee e = new Employee();
                String name = rs.getString(1);
                DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
                String time = df.format(rs.getDate("BIRTHDATE"));
                String username = rs.getString(3);
                String nachname = rs.getString(4);
                String role_name = rs.getString("ROLENAME");
                e = new Employee(name, time, username, nachname);
                e.setRole_name(role_name);
                temp.add(e);

            }
        } catch (Exception e) {
            throw e;
        }
        return temp;
    }

    public void insertEmployee(Employee e) throws Exception {
        String st = "INSERT INTO EMPLOYEES VALUES(?, ?, ?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setString(1, e.getName());
            DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
            java.util.Date d = df.parse(e.getBirthdate());
            java.sql.Date dd = new java.sql.Date(d.getTime());
            ps.setDate(2, dd);
            ps.setString(3, e.getUsername());
            ps.setString(4, e.getNachname());
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void deleteEmployee(String username) throws Exception {
        String s = "DELETE FROM EMPLOYEES WHERE USERNAME = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setString(1, username);
            ps.executeUpdate();
        } catch (Exception e) {
            throw e;
        }
    }

    public void updateEmployee(Employee e) throws Exception {
        String st = "UPDATE EMPLOYEES SET NAME = ?, BIRTHDATE = ?, NACHNAME = ? WHERE USERNAME = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);

            ps.setString(1, e.getName());
            DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
            java.util.Date d = df.parse(e.getBirthdate());
            java.sql.Date dd = new java.sql.Date(d.getTime());
            ps.setDate(2, dd);
            ps.setString(3, e.getNachname());
            ps.setString(4, e.getUsername());

            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void updateMeal(Meal m) throws Exception {
        String st = "UPDATE MEALS SET MEALTYPE = ?, MEALNAME = ?, PRICE = ? WHERE ID_MEAL = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, m.getMealType());
            ps.setString(2, m.getName());
            ps.setDouble(3, m.getPrice());
            ps.setInt(4, m.getId());
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public void removeMeal(int id) throws Exception {
        String s = "DELETE FROM MEALS WHERE ID_MEAL = ?";
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setInt(1, id);
            ps.executeUpdate();
        } catch (Exception e) {
            throw e;
        }
    }

    public void insertMeal(Meal m) throws Exception {
        String st = "INSERT INTO MEALS VALUES(sequenceIncrementIDMeal.NEXTVAL, ?, ?, ?)";
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, m.getMealType());
            ps.setString(2, m.getName());
            ps.setDouble(3, m.getPrice());

            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public List<Addon> getAllAddons() throws Exception {
        String s = "SELECT * FROM ADDONS";
        List<Addon> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Addon>();
            while (rs.next()) {
                Addon a = new Addon();
                a = new Addon(rs.getInt(1), rs.getString(2), rs.getInt(3), rs.getString(4));
                temp.add(a);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public void orderAddOn(AddonWrapper a) throws Exception {

        String st = "INSERT INTO STAYSHAVEADDONS VALUES(?, ?)";
        System.out.println("dddddddddd");
        int id_stays = getStayIDByUsername(a.getUsername());
        try {
            PreparedStatement ps = createConnection().prepareStatement(st);
            ps.setInt(1, id_stays);
            ps.setInt(2, a.getId_addon());
            ps.executeUpdate();
        } catch (Exception ex) {
            throw ex;
        }
    }

    public int getStayIDByUsername(String u) throws Exception {
        String s = "SELECT * FROM STAYS WHERE USERNAME = ?";
        int id = -1;
        try {
            PreparedStatement ps = createConnection().prepareStatement(s);
            ps.setString(1, u);
            ResultSet rs = ps.executeQuery();
            while (rs.next()) {
                id = rs.getInt(1);
            }
        } catch (Exception e) {
            throw e;
        }
        return id;
    }

    public List<SnackCategory> getAllSnackCats() throws Exception {
        String s = "SELECT * FROM SNACK_CATEGORY";
        List<SnackCategory> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<SnackCategory>();
            while (rs.next()) {
                SnackCategory a = new SnackCategory();
                a = new SnackCategory(rs.getString(1));
                temp.add(a);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;

    }

    public List<Snack> getAllSnacks() throws Exception {
        String s = "SELECT * FROM SNACK";
        List<Snack> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<Snack>();
            while (rs.next()) {
                Snack a = new Snack();
                int id = rs.getInt(1);
                String type = rs.getString(2);
                String name = rs.getString(3);
                int price = rs.getInt(4);
                a = new Snack(id, type, name, price);
                temp.add(a);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;

    }

    public void insertOrderCart(SnackOrder o) throws Exception {
        String s = "INSERT INTO SNACK_ORDER VALUES(?, ?, ?)";
        int id_stay = this.getStayIDByUsername(o.getUsername());
        for (int i = 0; i < o.getSh().size(); i++) {
            try {
                PreparedStatement ps = createConnection().prepareStatement(s);

                ps.setInt(1, o.getSh().get(i).getSnack().getId_Snack());
                ps.setInt(2, o.getSh().get(i).getAmount());
                ps.setInt(3, id_stay);
                ps.executeUpdate();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }

    public void insertListOfMealsToStay(MealWrapper w) throws Exception {
        String s = "INSERT INTO ORDERS VALUES(?, ?, ?)";
        int id_stay = this.getStayIDByUsername(w.getUsername());
        for (int i = 0; i < w.getListOfMeals().size(); i++) {
            try {
                PreparedStatement ps = createConnection().prepareStatement(s);

                ps.setInt(1, id_stay);
                ps.setInt(2, w.getListOfMeals().get(i));
                
                DateFormat df = new SimpleDateFormat("dd.MMM.yyyy");
                java.util.Date d = df.parse("20.Apr.2012");
                java.sql.Date dd = new java.sql.Date(d.getTime());
                ps.setDate(3, dd);
                ps.executeUpdate();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
    
    public List<MealOrderWrapper> getAllMealOrders () throws Exception{
        String s = "select username, mealname from orders inner join stays on orders.KEY_STAY = stays.ID_STAYS inner join meals on meals.ID_MEAL = key_meals";
        
        List<MealOrderWrapper> temp = null;
        try {
            Statement st = createConnection().createStatement();
            ResultSet rs = st.executeQuery(s);
            temp = new ArrayList<MealOrderWrapper>();
            while (rs.next()) {
                MealOrderWrapper a = new MealOrderWrapper();
                String  username = rs.getString(1);
                String mealname = rs.getString(2);
                a = new MealOrderWrapper(username, mealname);
                temp.add(a);
            }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }
    
    public int getMealIDByName(String mealname)
    {
        String s = "SELECT * from meals where mealname = ?";
        
        try {
             PreparedStatement ps = createConnection().prepareStatement(s);
             ps.setString(1, mealname);
             ResultSet rs = ps.executeQuery(s);
             while(rs.next())
             {
                 return rs.getInt(1);
             }
        } catch (Exception ex) {
            Logger.getLogger(Database.class.getName()).log(Level.SEVERE, null, ex);
        }
    return -1;
    }
    
    public void deleteOrderWrapper(MealOrderWrapper w) {
        String s = "DELETE FROM ORDERS WHERE KEY_MEALS = ? AND KEY_STAY = ?";
        try {
             int id_stay = this.getStayIDByUsername(w.getUsername());
             PreparedStatement ps = createConnection().prepareStatement(s);
             ps.setInt(1, getMealIDByName(w.getMealname()));
             ps.setInt(2, id_stay);
             ps.executeUpdate();
        } catch (Exception ex) {
            Logger.getLogger(Database.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    public List<SnacksByUser> getSnacksByUser(String u) throws Exception {
         String s = "select snack_name, price, amount, amount*price as total from snack_order inner join SNACK on SNACK.ID_SNACK = snack_order.ID_SNACK inner join stays on stays.ID_STAYS = snack_order.ID_STAY where id_stay in (select id_stays from stays where username=?)";
        
        List<SnacksByUser> temp = null;
        temp = new ArrayList<SnacksByUser>();
        try {
           PreparedStatement ps = createConnection().prepareStatement(s);
           ps.setString(1, u);
           ResultSet rs = ps.executeQuery();
           while(rs.next())
           {
               String s_name = rs.getString(1);
               int price = rs.getInt(2);
               int amount = rs.getInt(3);
               int total = rs.getInt(4);
               SnacksByUser temp2 = new SnacksByUser (s_name, price, amount, total);
               temp.add(temp2);
           }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
    }

    public List<Coordinate> getCoordinates() throws Exception{
        String s = "select T.x, T.y from raumplan, TABLE(SDO_UTIL.GETVERTICES(shape)) T";
        List<Coordinate> temp;
        temp = new ArrayList<Coordinate>();
        try {
           PreparedStatement ps = createConnection().prepareStatement(s);
           ResultSet rs = ps.executeQuery();
           while(rs.next())
           {
              int x = rs.getInt(1);
              int y = rs.getInt(2);
              Coordinate c = new Coordinate(x, y);
              temp.add(c);
           }

        } catch (Exception ex) {
            throw ex;
        }
        return temp;
        
    }
}
