/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import java.util.ArrayList;
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
import javax.ws.rs.QueryParam;
import javax.ws.rs.core.MediaType;
import pkgModel.Database;
import pkgModel.Room;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("rooms")
public class RoomsResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of RoomsResource
     */
    public RoomsResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.RoomsResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public Room getRoomByID(@QueryParam("id") int id) throws Exception {
        Room r = null;
        try{
           r = Database.getInstance().getRoomByID(id);
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return r;
    }
    
    @Path("allrooms")
    @GET
    @Consumes(MediaType.APPLICATION_JSON)
    public List<Room> getAllRooms() throws Exception
    {
        List<Room> r = new ArrayList<Room>();
        try{
           r = Database.getInstance().getAllRooms();
        }
        catch(Exception ex)
        {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
        return r;
    }
    /**
     * PUT method for updating or creating an instance of RoomsResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    public void putXml(Room r) throws Exception {
        try {
            Database.getInstance().updateRoom(r);
        } catch (Exception ex) {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    public void insertRoom(Room r) throws Exception
    {
        try {
            Database.getInstance().insertRoom(r);
        } catch (Exception ex) {
            Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
            throw ex;
        }
    }
    
    @DELETE
    @Consumes(MediaType.APPLICATION_JSON)
    public void deleteRoom(int id) throws Exception
    {
        try{
           Database.getInstance().deleteRoom(id);
        }
        catch(Exception ex)
        {
             Logger.getLogger(RoomsResource.class.getName()).log(Level.SEVERE, null, ex);
             throw ex;
        }
    }
}
