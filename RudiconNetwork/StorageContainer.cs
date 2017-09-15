/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Class for single file storage (one file - one container) (many files - many containers - one warehouse)
 * 
 *  @created 2017-09-12 Artem Nikolaev
 * 
 *  
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudiconNetwork
{
    public class StorageContainer
    {
        //private 
        string FileName;

        string PartName;

        string MD5;

        string Owner;

        string FileID;

        string OriginID;

        uint FileSize;

        uint OriginSize;


        // Default empty container
        public StorageContainer()
        {
            FileName = "";
            PartName = "";
            MD5 = "";
            Owner = "";
            FileID = "";
            OriginID = "";
            FileSize = 0;
            OriginSize = 0;
        }


        // @return true if Container is empty
        public bool IsEmpty()
        {
            bool result = true;

            result &= FileName.Length > 0;
            result &= PartName.Length > 0;
            result &= MD5.Length > 0;
            result &= Owner.Length > 0;
            result &= FileID.Length > 0;
            result &= FileName.Length > 0;
            result &= OriginID.Length > 0;
            result &= FileSize > 0;
            result &= OriginSize > 0;

            return !result;
        }
    }
}
