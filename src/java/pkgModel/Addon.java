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
public class Addon {
    private int id_addon;
    private String name;
    private int price;
    private String desc;

    public Addon() {
    }

    public Addon(int id_addon, String name, int price, String desc) {
        this.id_addon = id_addon;
        this.name = name;
        this.price = price;
        this.desc = desc;
    }

    public int getId_addon() {
        return id_addon;
    }

    public void setId_addon(int id_addon) {
        this.id_addon = id_addon;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    public String getDesc() {
        return desc;
    }

    public void setDesc(String desc) {
        this.desc = desc;
    }
    
    
}
