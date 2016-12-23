/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author John_13
 */
@XmlRootElement
public class Role {
    private int ID_Role;
    private String name;
    private List<Permission> collPermissions;

    public Role() {
        collPermissions = new ArrayList<Permission>();
    }

    public Role(int ID_Role, String name) {
        this.ID_Role = ID_Role;
        this.name = name;
    }

    public int getID_Role() {
        return ID_Role;
    }

    public void setID_Role(int ID_Role) {
        this.ID_Role = ID_Role;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Permission> getCollPermissions() {
        return collPermissions;
    }

    public void setCollPermissions(List<Permission> collPermissions) {
        this.collPermissions = collPermissions;
    }
    
    
}
