using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//This class would get information via HTTP requests such as: get post put delete
namespace TicketingSystem
{
    class REST
    {
        //query, to get information only and not modify it
        //if resource is found, return http response code 200 (OK) along with response body
        //if not found, then return 404 (Not Found)
        //if get request is not correctly formed, return 400 (Bad Request)
        public static async Task HttpGet()
        {

        }

        //Create a new resource into a collection of resources
        //if resource created, return code 201 (Created)
        //if action performed by Post method results in resource not being identified by URI, either 200 (OK) or 204 (No Content) are viable
        public static async Task HttpPost()
        {

        }

        //update existing resource, if resource doesn't not exist, then can choose to create it
        //if resource created, must inform user with response code 201
        //if existing resource is modified, should send 200 (OK) or 204 (No Content)
        public static async Task HttpPut()
        {

        }

        //delete resources
        //if successful, return 200 (OK)
        //if the reponse includes an entity describing the status then return 202 (Accepted)
        //if the action is queued, return 404 (Not Found)
        public static async Task HttpDelete()
        {

        }
        
    }
}
