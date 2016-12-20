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
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.DELETE;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Guest;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("guests")
public class GuestsResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of GuestsResource
     */
    public GuestsResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.GuestsResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Guest> getAllGuests() throws Exception {
         List<Guest> ret = null;
        try {
            ret = Database.getInstance().getAllGuests();
        } catch (Exception ex) {
            Logger.getLogger(GuestsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return ret;
    }

    /**
     * PUT method for updating or creating an instance of GuestsResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_XML)
    public void insertGuest(Guest content) throws Exception {
        try {
            Database.getInstance().insertGuest(content);
        } catch (Exception ex) {
            Logger.getLogger(GuestsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
   
    
}
