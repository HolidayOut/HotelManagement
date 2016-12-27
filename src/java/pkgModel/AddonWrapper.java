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
public class AddonWrapper {
    private String username;
    private int id_addon;

    public AddonWrapper()
    {

    }

    public AddonWrapper(int id_addon, String username) {
        this.id_addon = id_addon;
        this.username = username;
    }

    public int getId_addon() {
        return id_addon;
    }

    public void setId_addon(int id_addon) {
        this.id_addon = id_addon;
    }

   

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    @Override
    public String toString() {
        return "AddonWrapper{" + "username=" + username + ", id_addon=" + id_addon + '}';
    }
    
    
}
