/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author John_13
 */
@XmlRootElement
public class Employee {
    
    private String name;
    private LocalDate birthDate;
    private String username;
    private String nachname;
    

   

    public Employee() {
    }

    public Employee(String name, String birthDate, String username, String nachname) {
        this.name = name;
        setBirthdate(birthDate);
        this.username = username;
        this.nachname = nachname;
    }


    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getBirthdate() {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       String formattedString = birthDate.format(formatter);
       return formattedString;
    }

    public void setBirthdate(String checkin) {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       formatter = formatter.withLocale( Locale.GERMANY );  // Locale specifies human language for translating, and cultural norms for lowercase/uppercase and abbreviations and such. Example: Locale.US or Locale.CANADA_FRENCH
       this.birthDate  = LocalDate.parse(checkin, formatter);
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getNachname() {
        return nachname;
    }

    public void setNachname(String nachname) {
        this.nachname = nachname;
    }
    
    
}
