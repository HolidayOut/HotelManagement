/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.util.logging.Level;
import java.util.logging.Logger;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.SnackOrder;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("snackorder")
public class SnackorderResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of SnackorderResource
     */
    public SnackorderResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.SnackorderResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_XML)
    public String getXml() {
        //TODO return proper representation object
        throw new UnsupportedOperationException();
    }

    /**
     * PUT method for updating or creating an instance of SnackorderResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void addOrderCart(SnackOrder o) throws Exception
    {
        try {
            Database.getInstance().insertOrderCart(o);
        } catch (Exception ex) {
            Logger.getLogger(SnackorderResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
}
