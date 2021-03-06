﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MalApi;
using System.Threading;
using Xunit;

namespace MalApi.UnitTests
{
    public class AnimeListCacheTests
    {
        [Fact]
        public void TestCacheCaseInsensitivity()
        {
            using (AnimeListCache cache = new AnimeListCache(expiration: TimeSpan.FromHours(5)))
            {
                cache.PutListForUser("a", new MalUserLookupResults(userId: 5, canonicalUserName: "A", animeList: new List<MyAnimeListEntry>(), mangaList: new List<MyMangaListEntry>()));
                cache.GetListForUser("A", out MalUserLookupResults lookup);
                Assert.Equal(5, lookup.UserId);
            }
        }
    }
}

/*
 Copyright 2017 Greg Najda

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/