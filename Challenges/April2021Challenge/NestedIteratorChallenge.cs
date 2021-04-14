using System.Collections.Generic;
using System.Diagnostics;
using DataStructures;
using Xunit;

namespace ChallengesTests.April2021Challenge
{
    public class NestedIteratorChallenge : IChallenge
    {
        public string Link
            => "https://leetcode.com/explore/featured/card/april-leetcoding-challenge-2021/594/week-2-april-8th-april-14th/3706/";

        [Fact]
        public void NestedIteratorTests1()
        {
            var list = new List<NestedInteger>
            {
                new(new List<NestedInteger>
                {
                    new(1),
                    new(2)
                }),
                new (3),
                new(new List<NestedInteger>
                {
                    new(4),
                    new(5)
                })
            };

            var arr = new int[5];
            var index = 0;
            NestedIterator i = new NestedIterator(list);
            while (i.HasNext())
            {
                arr[index++] = i.Next();
            }
               
            Assert.Equal(new [] {1,2,3,4,5}, arr);
        }
        
        [Fact]
        public void NestedIteratorTest2()
        {
            var list = new List<NestedInteger>
            {
                new(new List<NestedInteger>())
            };

            NestedIterator i = new NestedIterator(list);
            Assert.False(i.HasNext());
        }
        
        public class NestedIterator {
            private NestedInteger? _current;
            private IList<NestedInteger> _nestedList;
            private Stack<ParentLink> _parents;
    
            private class ParentLink{
                public NestedInteger? Parent {get;set;}
                public int ParentIndex {get;set;}
            }
    
            public NestedIterator(IList<NestedInteger> nestedList) {
                _nestedList = nestedList;
                _parents = new Stack<ParentLink>();
        
                _current = _nestedList[0];
                _parents.Push(new ParentLink
                {
                    Parent = null,
                    ParentIndex = -1
                });
                GoNext();
            }

            private void GoNext()
            {
                ParentLink? parent = null;
                IList<NestedInteger>? list = null;
                while (_parents.Count > 0) {
                    parent = _parents.Pop();
                    if (parent.Parent == null)
                        break;
                    
                    list = parent.Parent.GetList();
                    if (parent.ParentIndex < list.Count - 1)
                        break;
                }

                Debug.Assert(parent != null, nameof(parent) + " != null");
                var currentIndex = parent.ParentIndex + 1;
                if (parent.Parent == null && parent.ParentIndex >= _nestedList.Count - 1){
                    _current = null;
                    return;
                }

                if (parent.Parent == null)
                {
                    _current = _nestedList[parent.ParentIndex + 1];
                }
                else
                {
                    Debug.Assert(list != null, nameof(list) + " != null");
                    _current = list[parent.ParentIndex + 1];
                }

                _parents.Push(new ParentLink{
                    Parent = parent.Parent,
                    ParentIndex = currentIndex
                });
                
                while (!_current.IsInteger()){
                    _parents.Push(new ParentLink{
                        Parent = _current,
                        ParentIndex = 0
                    });
                    list = _current.GetList();
                    if (list.Count == 0)
                    {
                        GoNext();
                        return;
                    }
                    _current = list[0];
                }
            }
    
            public bool HasNext() {
                return _current != null;
            }

            public int Next() {
                if (_nestedList.Count == 0)
                    return -1;                                       
        
                if (_current == null)
                    return -1;

                var result = _current.GetInteger();
                GoNext();
                return result;
            }
        }
    }
}