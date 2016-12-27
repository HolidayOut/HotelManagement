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
public class MealWrapper {
   private List<Integer> listOfMeals;
    private String username;

    public MealWrapper() {
        listOfMeals = new ArrayList<Integer>();
    }

    public MealWrapper(List<Integer> listOfMeals, String username) {
        this.listOfMeals = listOfMeals;
        this.username = username;
    }

    public List<Integer> getListOfMeals() {
        return listOfMeals;
    }

    public void setListOfMeals(List<Integer> listOfMeals) {
        this.listOfMeals = listOfMeals;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
    
}
