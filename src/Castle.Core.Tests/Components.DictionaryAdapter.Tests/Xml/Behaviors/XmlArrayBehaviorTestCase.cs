﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.Components.DictionaryAdapter.Xml.Tests
{
	using System;
	using System.Xml.Serialization;
	using Castle.Components.DictionaryAdapter.Tests;
    using NUnit.Framework;

	public class XmlArrayBehaviorTestCase
	{
        [TestFixture]
        public class ArrayBehavior : XmlAdapterTestCase
        {
            [Test]
            public void GetProperty_ArrayBehavior_Array_Element()
            {
                var foo = Create<IRoot>("<Root> <X> <A X='1'/> <B X='1'/> </X> </Root>");

				var array = foo.Items;

                Assert.That(array,    Is.Not.Null & Has.Length.EqualTo(2));
                Assert.That(array[0], Is.InstanceOf<IDerived1>());
                Assert.That(array[1], Is.InstanceOf<IDerived2>());
            }

            //[Test]
            //public void SetProperty_ArrayBehavior_Array()
            //{
            //    var array = new[] { 1, 2 };
            //    var xml = Xml("<Foo/>");
            //    var foo = Create<IRoot>(xml);

            //    foo.F = array;

            //    Assert.That(xml, XmlEquivalent.To("<Foo> <F> <int>1</int> <int>2</int> </F> </Foo>"));
            //}

            public interface IRoot
            {
                [XmlArray("X")]
                [XmlArrayItem("A", typeof(IDerived1))]
                [XmlArrayItem("B", typeof(IDerived2))]
                IBase[] Items { get; set; }
            }

            public interface IBase { }
            public interface IDerived1 : IBase { int    X { get; set; } }
            public interface IDerived2 : IBase { string X { get; set; } } 
        }
	}
}
