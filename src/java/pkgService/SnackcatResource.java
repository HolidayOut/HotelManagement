/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import pkgModel.Database;
import pkgModel.SnackCategory;
/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("snackcat")
public class SnackcatResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of SnackcatResource
     */
    public SnackcatResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.SnackcatResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<SnackCategory> getSnacks() throws Exception {
        List<SnackCategory> ret = null;
        try {
           ret = Database.getInstance().getAllSnackCats();
        } catch (Exception ex) {
            Logger.getLogger(SnackcatResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
      return ret;
    }

    /**
     * PUT method for updating or creating an instance of SnackcatResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
}
