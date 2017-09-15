/**
 *  RuDiCon Soft (c) 2017
 * 
 *  Class for storage data
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
    class Warehouse
    {
        List<StorageContainer> containers;

        //private 
        public bool Init()
        {
            try
            {
                fillContainers();
            }
            catch (Exception e)
            {
                
                throw e;
            }
            return true;
        }


        // Fill data to containers.
        private void fillContainers()
        {
            // get Local Storage path


            // get local storage files


            // add files to containers


            // 
        }

        


    }
}
