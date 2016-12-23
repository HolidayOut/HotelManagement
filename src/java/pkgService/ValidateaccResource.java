/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgService;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.UriInfo;
import javax.ws.rs.Produces;
import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.PUT;
import javax.ws.rs.core.MediaType;
import pkgModel.Account;
import pkgModel.Database;

/**
 * REST Web Service
 *
 * @author John_13
 */
@Path("validateacc")
public class ValidateaccResource {

    @Context
    private UriInfo context;

    /**
     * Creates a new instance of ValidateaccResource
     */
    public ValidateaccResource() {
    }

    /**
     * Retrieves representation of an instance of pkgService.ValidateaccResource
     * @return an instance of java.lang.String
     */
    @GET
    @Produces(MediaType.APPLICATION_XML)
    public String getXml() {
        //TODO return proper representation object
        throw new UnsupportedOperationException();
    }

    /**
     * PUT method for updating or creating an instance of ValidateaccResource
     * @param content representation for the resource
     */
    @PUT
    @Consumes(MediaType.APPLICATION_XML)
    public void putXml(String content) {
    }
    
    @POST
    @Consumes({MediaType.APPLICATION_JSON})
    @Produces({MediaType.APPLICATION_JSON})
    public Account validate(Account acc)
    {
        Account a = null;
        a = Database.getInstance().getAccountByUserPw(acc);
        System.out.println("****"+a);
        return a;
    }
}
