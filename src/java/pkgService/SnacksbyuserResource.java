/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.SnacksByUser;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("snacksbyuser")
public class SnacksbyuserResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of SnacksbyuserResource
     */
    public SnacksbyuserResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.SnacksbyuserResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<SnacksByUser> getXml(@QueryParam ("u") String u) {
        try {
            return Database.getInstance().getSnacksByUser(u);
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            Logger.getLogger(SnacksbyuserResource.class.getName()).log(Level.SEVERE, null, ex);
        }
        return null;
    }

    /**
     * PUT method for updating or creating an instance of SnacksbyuserResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
}
