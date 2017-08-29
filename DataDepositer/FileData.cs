/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Class for store info about selected file for encrypt
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDepositer
{
    public class FileData
    {
        private String filename;    // File name for work
        private String description; // File description for header 
        private String name;        // 
        private String password;

        public FileData()
        {

        }

        public FileData(String _filename, String _description , String _name, String _password)
        {
            filename = _filename;
            description = _description;
            name = _name;
            password = _password;
        }



    }
}
