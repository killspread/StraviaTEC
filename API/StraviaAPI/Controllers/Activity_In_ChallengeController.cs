﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StraviaAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StraviaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Activity_In_ChallengeController : ControllerBase
    {
        //Configuration to get connection string
        private readonly IConfiguration _configuration;

        public Activity_In_ChallengeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Get method for all activities in all challenges
        /// </summary>
        /// <returns>All activities in all challenges</returns>

        [HttpGet]
        public JsonResult GetAllActivities_Chall()
        {
            string query = @"
                             exec get_all_ActChallenge
                            "; //Select query sent to SQL Server
            DataTable table = new DataTable(); //Created table to save data
            string sqlDataSource = _configuration.GetConnectionString("StraviaTec");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))//Connection created
            {
                myCon.Open(); //Connection opened
                using (SqlCommand myCommand = new SqlCommand(query, myCon)) //Command with query and connection
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); //Load data to table
                    myReader.Close();
                    myCon.Close(); //Closed connection
                }
            }
            return new JsonResult(table);//Returns table 
        }

        /// <summary>
        /// Get method of a specific friend for a specific athlete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="friendid"></param>
        /// <returns>Athlete's requested friend</returns>

        [HttpGet("{activityid}/{challengeid}")]
        public JsonResult GetActChallenge(string activityid, string challengeid)
        {
            string query = @"
                             exec get_ActChallenge @activityid,@challengeid
                            "; //Select query sent to sql
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StraviaTec");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))//Connection created
            {
                myCon.Open(); //Connection opened
                using (SqlCommand myCommand = new SqlCommand(query, myCon))//Command with query and connection
                {
                    //Added parameters
                    myCommand.Parameters.AddWithValue("@activityid", activityid);
                    myCommand.Parameters.AddWithValue("@challengeid", challengeid);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); //Loads info to table
                    myReader.Close();
                    myCon.Close(); //Closed connection
                }
            }
            return new JsonResult(table); //Returns table
        }

        /// <summary>
        /// Post method for athlete's friend
        /// </summary>
        /// <param name="friend"></param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult PostAthFriend(Activity_In_Challenge actChallenge)
        {
            string sqlDataSource = _configuration.GetConnectionString("StraviaTec");
            //Primary Key validations



            string query = @"
                             exec post_ActChallenge @activityid,@challengeid
                            "; //Insert query sent to sql server
            DataTable table = new DataTable();

            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))//Connection started
            {
                myCon.Open(); //Opens connection
                SqlCommand myCommand = new SqlCommand(query, myCon);//Command with query and connection

                //Parameters added
                myCommand.Parameters.AddWithValue("@activityid", actChallenge.ActivityID);
                myCommand.Parameters.AddWithValue("@challengeid", actChallenge.ChallengeID);

                myReader = myCommand.ExecuteReader();
                table.Load(myReader);
                myReader.Close();
                myCon.Close(); //Closed connection

            }

            return Ok(); //Returns acceptance

        }

        /// <summary>
        /// Delte method for athlete's friend
        /// </summary>
        /// <param name="id"></param>
        /// <param name="friendID"></param>
        /// <returns>Reusult of query</returns>

        [HttpDelete]
        public ActionResult DeleteAthFriend(string activityid, string challengeid)
        {
            string query = @"
                             exec delete_ActChallenge @activityid,@challengeid
                            "; //Delete query sent to sql
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("StraviaTec");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))//Connection created
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon)) //Command eith query and connection
                {

                    //Added parameters with values
                    myCommand.Parameters.AddWithValue("@activityid", activityid);
                    myCommand.Parameters.AddWithValue("@challengeid", challengeid);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close(); //Connection closed
                }
            }
            return Ok(); //Returns Acceptance
        }

    }
}