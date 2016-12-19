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
    public String name;
    public LocalDate time;

    public Meal(String name, String time) {
        this.name = name;
        setTime(time);
    }

    public Meal() {
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getTime() {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MMM/yyyy");
       String formattedString = time.format(formatter);
       return formattedString;
    }

    public void setTime(String checkin) {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MMM/yyyy");
       formatter = formatter.withLocale( Locale.GERMANY );  // Locale specifies human language for translating, and cultural norms for lowercase/uppercase and abbreviations and such. Example: Locale.US or Locale.CANADA_FRENCH
       this.time  = LocalDate.parse(checkin, formatter);
    }
    
    
    
}
