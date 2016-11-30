/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 *
 * @author John_13
 */
@XmlRootElement
@XmlType(propOrder={"username", "password", "role_id"})
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
    
    
    
}
