﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MalApi
{
    // XML enum attributes are needed for proper serialization upon sending an update request
    public enum AnimeCompletionStatus
    {
        [XmlEnum(Name = "watching")]
        Watching = 1,
        [XmlEnum(Name = "completed")]
        Completed = 2,
        [XmlEnum(Name = "onhold")]
        OnHold = 3,
        [XmlEnum(Name = "dropped")]
        Dropped = 4,
        [XmlEnum(Name = "plantowatch")]
        PlanToWatch = 6,
    }
}

/*
 Copyright 2012 Greg Najda

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