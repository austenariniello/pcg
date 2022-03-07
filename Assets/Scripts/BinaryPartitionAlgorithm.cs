using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BinaryPartitionAlgorithm
{
    /*
    
    Bounds Int is struct that lets us make rooms with two points (AABB)
    we'll use BoundsInt as our rooms (BoundsInt room)
    room.min is bottom left corner of box/room
    room.size.x is width of room
    room.size.y is height of room

    */ 

    public static List<BoundsInt> BinarySpacePartitioning(BoundsInt initialRoom, int minWidth, int minHeight)
    {
        Queue<BoundsInt> roomsQueue = new Queue<BoundsInt>();   // queue of rooms that will be split
        List<BoundsInt> roomsList = new List<BoundsInt>();  // list of valid rooms that will no longer be split

        roomsQueue.Enqueue(initialRoom);

        while (roomsQueue.Count > 0)
        {
            var room = roomsQueue.Dequeue();

            // y is height of room, x is width of room
            if (room.size.y >= minHeight && room.size.x >= minWidth)
            {
                // randomly decide whether to split horizontally or vertically
                if(Random.value < 0.5f)
                {   // horizontal split
                    // first check if it is possible to split horizontally, if not then split vertically
                    if (room.size.y >= minHeight * 2)   // check if room is large enough to split
                    {   
                        SplitHorizontally(minHeight, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth * 2)
                    {
                        SplitVertically(minWidth, roomsQueue, room);
                    }
                    else
                    {
                        // if it cannot be split then just add to rooms list
                        // not added to room queue bc it cannot be split
                        roomsList.Add(room);
                    }
                }
                else
                {   // vertical split
                    if (room.size.y >= minHeight * 2)
                    {
                        SplitVertically(minWidth, roomsQueue, room);
                    }
                    else if (room.size.x >= minWidth * 2)
                    {
                        SplitHorizontally(minHeight, roomsQueue, room);
                    }
                    else
                    {
                        // if it cannot be split then just add to rooms list
                        // not added to room queue bc it cannot be split
                        roomsList.Add(room);
                    }
                }
            }
        }
        return roomsList;
    }

    private static void SplitVertically(int minWidth, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var xSplit = Random.Range(1, room.size.x);  // find a point in between 1 and room width to split across
        
        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(xSplit, room.min.y, room.min.z));  // first room has same min point and height as original room, width is the position chosen to split the rooms at
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x + xSplit, room.min.y, room.min.z), // second room has same height as original room, min point is now min point of og + xSplit and width is og room width - xSplit point
            new Vector3Int(room.size.x - xSplit, room.size.y, room.size.z));  

        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }

    private static void SplitHorizontally(int minHeight, Queue<BoundsInt> roomsQueue, BoundsInt room)
    {
        var ySplit = Random.Range(1, room.size.y);

        BoundsInt room1 = new BoundsInt(room.min, new Vector3Int(room.size.x, ySplit, room.size.z));    // first room has same min positions as og, height is now ySplit
        BoundsInt room2 = new BoundsInt(new Vector3Int(room.min.x, room.min.y + ySplit, room.min.z),    // second room is og min point + ysplit for height, height is og height - ysplit
            new Vector3Int(room.size.x, room.size.y - ySplit, room.size.z));

        roomsQueue.Enqueue(room1);
        roomsQueue.Enqueue(room2);
    }
}
