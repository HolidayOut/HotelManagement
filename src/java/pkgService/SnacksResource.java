/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.util.List;
import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Consumes;
import javax.ws.rs.Produces;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Snack;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("snacks")
public class SnacksResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of SnacksResource
     */
    public SnacksResource() {
    }

    /**
     * Retrieves representation of an instance of pkgModel.SnacksResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Snack> getXml() throws Exception{
        List<Snack> ret = null;
        
       try{
           ret = Database.getInstance().getAllSnacks();
       }
       catch(Exception ex)
       {
           throw ex;
       }
       return ret;
    }

    /**
     * PUT method for updating or creating an instance of SnacksResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
}
