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
public class Guest {
    private String username;
    private String name;

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Guest() {
    }

    public Guest(String name, String username) {
       this.name = name;
       this.username = username;
    }
    
    
}