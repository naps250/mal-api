﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace MalApi.UnitTests
{
    class MalDetailScrapingUtils
    {
        public static AnimeUpdate ScrapeUserAnimeDetailsFromHtml(string userAnimeDetailsHtml)
        {
            AnimeUpdate results = new AnimeUpdate();

            var doc = new HtmlDocument();
            doc.LoadHtml(userAnimeDetailsHtml);

            // Episode
            results.Episode = doc.GetElementbyId("add_anime_num_watched_episodes").GetAttributeValue("value", -1);

            // Status
            var parentNode = doc.GetElementbyId("add_anime_status");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Status = (AnimeCompletionStatus)childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Enable rewatching
            results.EnableRewatching = doc.GetElementbyId("add_anime_is_rewatching").Attributes["checked"] == null ? 0 : 1;

            // Score
            parentNode = doc.GetElementbyId("add_anime_score");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Score = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Start date
            int day = -1;
            int month = -1;
            int year = -1;
            parentNode = doc.GetElementbyId("add_anime_start_date_month");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    month = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_anime_start_date_day");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    day = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_anime_start_date_year");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    year = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            if (month == -1 || day == -1 || year == -1)
            {
                results.DateStart = null;
            }
            else
            {
                results.DateStart = new DateTime(year, month, day);
            }

            // Date finish
            parentNode = doc.GetElementbyId("add_anime_finish_date_month");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    month = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_anime_finish_date_day");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    day = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_anime_finish_date_year");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    year = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            if (month == -1 || day == -1 || year == -1)
            {
                results.DateFinish = null;
            }
            else
            {
                results.DateFinish = new DateTime(year, month, day);
            }

            // Tags
            results.Tags = doc.GetElementbyId("add_anime_tags").InnerText;

            // Priority
            parentNode = doc.GetElementbyId("add_anime_priority");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Priority = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Storage type
            parentNode = doc.GetElementbyId("add_anime_storage_type");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.StorageType = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Storage value
            results.StorageValue = doc.GetElementbyId("add_anime_storage_value").GetAttributeValue("value", -1);

            // Times rewatched
            results.TimesRewatched = doc.GetElementbyId("add_anime_num_watched_times").GetAttributeValue("value", -1);

            // Rewatch value
            parentNode = doc.GetElementbyId("add_anime_rewatch_value");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.RewatchValue = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Comments
            results.Comments = doc.GetElementbyId("add_anime_comments").InnerText;

            // Enable discussion
            parentNode = doc.GetElementbyId("add_anime_is_asked_to_discuss");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    // Because 'Enable discussion = 1' sent for update sets the first options of the dropdown, which corresponds to 0 and vice versa...
                    int temp = childNode.GetAttributeValue("value", -1);
                    temp = temp == 1 ? 0 : 1;
                    results.EnableDiscussion = temp;
                    break;
                }
            }

            return results;
        }

        public static  MangaUpdate ScrapeUserMangaDetailsFromHtml(string userMangaDetailsHtml)
        {
            MangaUpdate results = new MangaUpdate();

            var doc = new HtmlDocument();
            doc.LoadHtml(userMangaDetailsHtml);

            // Chapter
            results.Chapter = doc.GetElementbyId("add_manga_num_read_chapters").GetAttributeValue("value", -1);

            // Volume
            results.Volume = doc.GetElementbyId("add_manga_num_read_volumes").GetAttributeValue("value", -1);

            // Status
            var parentNode = doc.GetElementbyId("add_manga_status");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Status = (MangaCompletionStatus)childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Enable rereading
            results.EnableRereading = doc.GetElementbyId("add_manga_is_rereading").Attributes["checked"] == null ? 0 : 1;

            // Score
            parentNode = doc.GetElementbyId("add_manga_score");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Score = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Start date
            int day = -1;
            int month = -1;
            int year = -1;
            parentNode = doc.GetElementbyId("add_manga_start_date_month");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    month = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_manga_start_date_day");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    day = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_manga_start_date_year");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    year = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            if (month == -1 || day == -1 || year == -1)
            {
                results.DateStart = null;
            }
            else
            {
                results.DateStart = new DateTime(year, month, day);
            }

            // Date finish
            parentNode = doc.GetElementbyId("add_manga_finish_date_month");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    month = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_manga_finish_date_day");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    day = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            parentNode = doc.GetElementbyId("add_manga_finish_date_year");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    year = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }
            if (month == -1 || day == -1 || year == -1)
            {
                results.DateFinish = null;
            }
            else
            {
                results.DateFinish = new DateTime(year, month, day);
            }

            // Tags
            results.Tags = doc.GetElementbyId("add_manga_tags").InnerText;

            // Priority
            parentNode = doc.GetElementbyId("add_manga_priority");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.Priority = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Times reread
            results.TimesReread = doc.GetElementbyId("add_manga_num_read_times").GetAttributeValue("value", -1);

            // Reread value
            parentNode = doc.GetElementbyId("add_manga_reread_value");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    results.RereadValue = childNode.GetAttributeValue("value", -1);
                    break;
                }
            }

            // Comments
            results.Comments = doc.GetElementbyId("add_manga_comments").InnerText;

            // Enable discussion
            parentNode = doc.GetElementbyId("add_manga_is_asked_to_discuss");
            foreach (var childNode in parentNode.ChildNodes)
            {
                if (childNode.Attributes["selected"] != null)
                {
                    // Because 'Enable discussion = 1' sent for update sets the first options of the dropdown, which corresponds to 0 and vice versa...
                    int temp = childNode.GetAttributeValue("value", -1);
                    temp = temp == 1 ? 0 : 1;
                    results.EnableDiscussion = temp;
                    break;
                }
            }

            return results;
        }
    }
}
