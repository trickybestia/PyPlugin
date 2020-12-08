using IronPython.Runtime;
using System.Collections.Generic;

namespace PyPlugin.EmbeddedScriptsApi
{
    public static class Coroutine
    {
        /// <summary>
        /// Wraps <see cref="PythonGenerator"/> in <see cref="IEnumerator{T}"/>.
        /// </summary>
        /// <param name="generator">Python generator.</param>
        /// <returns><see cref="IEnumerator{T}"/> which takes values from <paramref name="generator"/></returns>
        public static IEnumerator<T> ToIEnumerator<T>(PythonGenerator generator)
        {
            foreach (var generatorResult in generator)
                yield return (T)generatorResult;
        }
    }
}
