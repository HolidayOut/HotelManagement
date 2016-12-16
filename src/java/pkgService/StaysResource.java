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
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Stay;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("stays")
public class StaysResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of StaysResource
     */
    public StaysResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.StaysResource
     *
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Stay> getXml() throws Exception {
        return Database.getInstance().getAllStays();
    }

    /**
     * PUT method for updating or creating an instance of StaysResource
     *
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }

    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Stay insertStay(Stay stay) throws Exception{
        try {
            Database.getInstance().insertStay(stay);
            return stay;
        } catch (Exception ex) {
           throw ex;
        }
    }
}
