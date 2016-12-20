/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgModel;

/**
 *
 * @author John_13
 */
public class Room {
    private int id;
    private int roomsize;
    private int roomprize;

    public Room() {
    }

    public Room(int id, int roomsize, int roomprize) {
        this.id = id;
        this.roomsize = roomsize;
        this.roomprize = roomprize;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getRoomsize() {
        return roomsize;
    }

    public void setRoomsize(int roomsize) {
        this.roomsize = roomsize;
    }

    public int getRoomprize() {
        return roomprize;
    }

    public void setRoomprize(int roomprize) {
        this.roomprize = roomprize;
    }
    
    
}
