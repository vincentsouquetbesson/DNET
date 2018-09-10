using System;
using SocialNetwork.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SocialNetwork.Controllers
{
    [RoutePrefix("personalspace")]
    public class PersonalSpaceController : Controller
    {
        // GET: PersonalSpace
        public ActionResult Index()
        {
            System.Diagnostics.Debug.WriteLine("*******************************");
            System.Diagnostics.Debug.WriteLine("     PERSONAL SPACE");
            System.Diagnostics.Debug.WriteLine("*******************************");
            SocialMediaBdd db = new SocialMediaBdd(); //ouverture de la bdd


            UserTO user = new UserTO();
            user.Id = Properties.Settings.Default.Id;
            user.FirstName = Properties.Settings.Default.FirstName;
            user.LastName = Properties.Settings.Default.LastName;
            user.Mail = Properties.Settings.Default.Mail;

            /************** Get friend list */


            IQueryable<UserTO> friendQuerry = from a in db.User
                                              join b in db.Friend.Where(t2 => t2.UserId == user.Id)
                                              on a.Id equals b.FriendId
                                              select new UserTO
                                              {
                                                  Id = a.Id,
                                                  Mail = a.Mail,
                                                  FirstName = a.FirstName,
                                                  LastName = a.LastName
                                              };

            /************** Get message list */
            // recuperation de publication de ami
            IQueryable<MessageTO> messageQuerry = from a in db.User
                                                  join b in db.Friend.Where(t2 => t2.UserId == user.Id )   
                                                  on a.Id equals b.UserId
                                                  join c in db.Message
                                                  on b.FriendId equals  c.UserId   ///ERREUR
                                                  select new MessageTO
                                                  {
                                                      Id = c.Id,
                                                      Message = c.Message1,
                                                      Date = c.Date
                                                  };

            //List < MessageTO > listMessage = new List<MessageTO>(messageQuerry.ToList());

             messageQuerry = from a in db.User
                            join c in db.Message
                            on a.Id equals c.UserId   ///ERREUR
                           select new MessageTO
                           {
                                Id = c.Id,
                                Message = c.Message1,
                                Date = c.Date
                           };
            List<MessageTO> listMessage = new List<MessageTO>(messageQuerry.ToList());
            //listMessage.AddRange(messageQuerry.ToList());



            if (messageQuerry != null)
            {
                foreach (MessageTO message in listMessage)
                {
                    IQueryable<UserTO> userMessage = from a in db.User
                                             join b in db.Message.Where(t2 => t2.Id == message.Id)
                                             on a.Id equals b.UserId
                                             select new UserTO
                                             {
                                                Id = a.Id,
                                                FirstName = a.FirstName,
                                                 LastName = a.LastName
                                             };








                    IQueryable<CommentTO> commentQuerry = from a in db.Message
                                                          join b in db.MessageComment.Where(t2 => t2.MessageId == message.Id)
                                                         on a.Id equals b.MessageId
                                                          select new CommentTO
                                                          {
                                                              Id = b.Id,
                                                              Comment = b.Comment,
                                                              Date = b.Date
                                                          };

                    List<CommentTO> commentList = new List<CommentTO>(commentQuerry.ToList());

                    foreach (CommentTO comment in commentList)
                    {
                        IQueryable<LikeCommentTO> likeCommentQuerry = from a in db.MessageComment.Where(t2 => t2.Id == comment.Id)
                                                                      join b in db.CommentLike
                                                              on a.Id equals b.CommentId
                                                               select new LikeCommentTO
                                                               {
                                                                   Id = b.Id,
                                                                   UserId = b.UserId,
                                                                   CommentId = message.Id
                                                               };
                        comment.Likelist = likeCommentQuerry.ToList();

                        IQueryable<UserTO> userComment = from a in db.User
                                                         join b in db.MessageComment.Where(t2 => t2.Id == comment.Id)
                                                         on a.Id equals b.UserId
                                                         select new UserTO
                                                         {
                                                             Id = a.Id,
                                                             FirstName = a.FirstName,
                                                             LastName = a.LastName
                                                             // date = b.Date;
                                                         };
                        foreach (UserTO usEr in userComment)
                        {
                            comment.User = usEr;
                            continue;
                        }
                        System.Diagnostics.Debug.WriteLine("*******************************");
                        System.Diagnostics.Debug.WriteLine(comment.User.FirstName);

                    }


                        IQueryable<MessageLikeTO> likeQuerry = from a in db.Message.Where(t2 => t2.Id == message.Id)
                                                               join b in db.MessageLike
                                                         on a.Id equals b.MessageId
                                                          select new MessageLikeTO
                                                          {
                                                              Id = b.Id,
                                                              UserId = b.UserId,
                                                              MessageId = message.Id
                                                          };
                    foreach (UserTO useR in userMessage) {
                        message.User = useR;
                        continue;
                    }



                    message.Commentlist = commentList;
                    message.Likelist = new List<MessageLikeTO>(likeQuerry.ToList() );

                }
            }


            ViewData["messages"] = new List<MessageTO>(listMessage);
            //   ViewData["messages"] = new List<MessageTO>( messageQuerry.ToList() ) ;
            ViewData["friends"] = new List<UserTO>( friendQuerry.ToList() );
            return View();
        }



        [HttpPost, ActionName("send")]
        [ValidateAntiForgeryToken]
        public ActionResult Send(string message)
        {
            if (message != null)
            {
                if (ModelState.IsValid)
                {
                    SocialMediaBdd db = new SocialMediaBdd(); //ouverture de la bdd
                    Message messageSend = new Message();

                    messageSend.UserId = Properties.Settings.Default.Id;
                    messageSend.Message1 = message;
                    messageSend.Date = DateTime.Now;
                    db.Entry(messageSend).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("*******************************");
                    System.Diagnostics.Debug.WriteLine("NOT VALIDE");
                    System.Diagnostics.Debug.WriteLine("*******************************");
                }
            }
            return RedirectToAction("index");
        }





    }
}