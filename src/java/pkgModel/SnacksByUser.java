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
public class SnacksByUser {
    private String snack_name;
    private int single_price;
    private int amount;
    private int total_price;

    public String getSnack_name() {
        return snack_name;
    }

    public void setSnack_name(String snack_name) {
        this.snack_name = snack_name;
    }

    public int getSingle_price() {
        return single_price;
    }

    public void setSingle_price(int single_price) {
        this.single_price = single_price;
    }

    public int getAmount() {
        return amount;
    }

    public void setAmount(int amount) {
        this.amount = amount;
    }

    public int getTotal_price() {
        return total_price;
    }

    public void setTotal_price(int total_price) {
        this.total_price = total_price;
    }
    
    public SnacksByUser()
    {
        
    }

    public SnacksByUser(String snack_name, int single_price, int amount, int total_price) {
        this.snack_name = snack_name;
        this.single_price = single_price;
        this.amount = amount;
        this.total_price = total_price;
    }
    
    
    
}
