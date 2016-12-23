/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author John_13
 */
@XmlRootElement
public class Wrapper {
    private int id_role;

    public int getId_role() {
        return id_role;
    }

    public void setId_role(int id_role) {
        this.id_role = id_role;
    }

    public int getId_permission() {
        return id_permission;
    }

    public void setId_permission(int id_permission) {
        this.id_permission = id_permission;
    }
    private int id_permission;

    public Wrapper() {
    }

    public Wrapper(int id_role, int id_permission) {
        this.id_role = id_role;
        this.id_permission = id_permission;
    }
    
    
    
}
