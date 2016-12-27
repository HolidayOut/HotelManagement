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
public class Snack {
    private int id_Snack;
    private String snackType;
    private String snackName;
    private int price;

    public Snack() {
    }

    public Snack(int id_Snack, String snackType, String snackName, int price) {
        this.id_Snack = id_Snack;
        this.snackType = snackType;
        this.snackName = snackName;
        this.price = price;
    }


    public int getId_Snack() {
        return id_Snack;
    }

    public void setId_Snack(int id_Snack) {
        this.id_Snack = id_Snack;
    }

    public String getSnackType() {
        return snackType;
    }

    public void setSnackType(String snackType) {
        this.snackType = snackType;
    }

    public String getSnackName() {
        return snackName;
    }

    public void setSnackName(String snackName) {
        this.snackName = snackName;
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }

    @Override
    public String toString() {
        return  snackName + "  €" + price;

    }
}
