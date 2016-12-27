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
public class SnackOrder {
    private List<SnackHelper> sh;
    private String username;

    public SnackOrder() {
        sh = new ArrayList<SnackHelper>();
    }

    public SnackOrder(List<SnackHelper> sh, String username) {
        this.sh = sh;
        this.username = username;
    }

    public List<SnackHelper> getSh() {
        return sh;
    }

    public void setSh(List<SnackHelper> sh) {
        this.sh = sh;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
