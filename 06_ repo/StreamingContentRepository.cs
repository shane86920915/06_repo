using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06__repo
{
    public class StreamingContentRepository
    {
        private List<StreamingContent> _listOfContent = new List<StreamingContent>();
        //creat
        public void AddContentToList(StreamingContent content)
        {
            _listOfContent.Add(content);

        }
        //read
        public List<StreamingContent> GetContentList()
        {
            return _listOfContent;

        }

        //update
        public bool UpdateExistingContent(string originalTitle, StreamingContent newContent)
        {
            //find the content
            StreamingContent oldContent = GetContentByTitle(originalTitle);

            //update the content
            if (oldContent != null)
            {
                oldContent.Title = newContent.Title;
                oldContent.Description = newContent.Description;
                oldContent.MaturityRating = newContent.MaturityRating;
                oldContent.IsFamilyFriendly = newContent.IsFamilyFriendly;
                oldContent.StarRating = newContent.StarRating;
                oldContent.TypeOfGenre = newContent.TypeOfGenre;
                return true;


            }

            else
            {
                return false;
            }
                    
                   

                    
                

        }


        //delete
        public bool RemoveContentFromList(string title)
        {
            StreamingContent content = GetContentByTitle(title);

            if (content == null)
            {
                return false;
            }
            int initialcount = _listOfContent.Count;
            _listOfContent.Remove(content);
            if (initialcount > _listOfContent.Count)
            {
                return true;
            }
            else
            {
                return false;
            }




        }
        
        //helpmethod
        public  StreamingContent GetContentByTitle(string title)
        {
            foreach(StreamingContent content in _listOfContent)
            {
                if (content.Title.ToLower() == title.ToLower())
                {
                    return content; 
                }

            }

            return null;


        }
    }
}
