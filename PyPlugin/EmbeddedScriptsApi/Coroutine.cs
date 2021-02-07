// -----------------------------------------------------------------------
// <copyright file="Coroutine.cs" company="TrickyBestia">
// Copyright (c) TrickyBestia. All rights reserved.
// Licensed under the CC BY-NC-SA 4.0 license.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

using IronPython.Runtime;

namespace PyPlugin.EmbeddedScriptsApi
{
    /// <summary>
    /// A class that provides API that wraps Python generator in .NET <see cref="IEnumerator{T}"/>.
    /// </summary>
    public static class Coroutine
    {
        /// <summary>
        /// Wraps <see cref="PythonGenerator"/> in <see cref="IEnumerator{T}"/>.
        /// </summary>
        /// <typeparam name="T">A type of returned <see cref="IEnumerator{T}"/>.</typeparam>
        /// <param name="generator">Python generator that will be wrapped.</param>
        /// <returns><see cref="PythonGenerator"/> wrapped in <see cref="IEnumerator{T}"/>.</returns>
        public static IEnumerator<T> ToIEnumerator<T>(PythonGenerator generator)
        {
            foreach (var generatorResult in generator)
            {
                yield return (T)generatorResult;
            }
        }
    }
}