/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;

/**
 *
 * @author John_13
 */
public class Meal {
    private String name;
    private LocalDate time;
    private int mealType;
    private double price;
    
    public Meal() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getTime() {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("DD.MM.YYYY");
       String formattedString = time.format(formatter);
       return formattedString;
    }

    public void setTime(String checkin) {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("DD.MM.YYYY");
       formatter = formatter.withLocale( Locale.GERMANY );  // Locale specifies human language for translating, and cultural norms for lowercase/uppercase and abbreviations and such. Example: Locale.US or Locale.CANADA_FRENCH
       this.time  = LocalDate.parse(checkin, formatter);
    }

    public int getMealType() {
        return mealType;
    }

    public void setMealType(int mealType) {
        this.mealType = mealType;
    }

    public double getPrice() {
        return price;
    }

    public void setPrice(double price) {
        this.price = price;
    }
    
    
    
    
}
