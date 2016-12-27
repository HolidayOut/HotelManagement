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
 public class SnackCategory  {
    private String snack_type;

    public SnackCategory(String snack_type) {
        this.snack_type = snack_type;
    }

    public SnackCategory() {
    }

    public String getSnack_type() {
        return snack_type;
    }

    public void setSnack_type(String snack_type) {
        this.snack_type = snack_type;
    }
}