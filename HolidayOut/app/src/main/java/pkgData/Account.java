package pkgData;

/**
 * Created by Andreas Druml on 22.12.2016.
 */
public class Account {
    private String username;
    private String password;
    private int role_id;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public int getRole_id() {
        return role_id;
    }

    public void setRole_id(int role_id) {
        this.role_id = role_id;
    }

    public Account() {
    }

    public Account(String username, String password, int role_id) {
        this.username = username;
        this.password = password;
        this.role_id = role_id;
    }

    @Override
    public String toString() {
        return "Account{" + "username=" + username + ", password=" + password + ", role_id=" + role_id + '}';
    }
}
