/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.Locale;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author John_13
 */
@XmlRootElement

public class Stay {
    
    private LocalDate checkin;
    private LocalDate checkout;
    private int id;
    private int roomID;
    private String username;
   
    public String getCheckin() {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       String formattedString = checkin.format(formatter);
       return formattedString;
    }

    public void setCheckin(String checkin) {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       formatter = formatter.withLocale( Locale.GERMANY );  // Locale specifies human language for translating, and cultural norms for lowercase/uppercase and abbreviations and such. Example: Locale.US or Locale.CANADA_FRENCH
       this.checkin  = LocalDate.parse(checkin, formatter);
    }

    public String getCheckout() {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       String formattedString = checkout.format(formatter);
       return formattedString;
    }

    public void setCheckout(String checkout) {
       DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd.MMM.yyyy");
       formatter = formatter.withLocale( Locale.GERMANY );  // Locale specifies human language for translating, and cultural norms for lowercase/uppercase and abbreviations and such. Example: Locale.US or Locale.CANADA_FRENCH
       this.checkout = LocalDate.parse(checkout, formatter);
    }
   
    
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public int getRoomID() {
        return roomID;
    }

    public void setRoomID(int roomID) {
        this.roomID = roomID;
    }

    public Stay() {
    }

    public Stay(int id, String username, int roomID, String in, String out) {
        this.id = id;
        this.username = username;
        this.roomID = roomID;
        setCheckin(in);
        setCheckout(out);
    }

    @Override
    public String toString() {
        return "Stay{" + "checkin=" + checkin + ", checkout=" + checkout + ", id=" + id + ", roomID=" + roomID + ", username=" + username + '}';
    }
    
    
    
    
}
