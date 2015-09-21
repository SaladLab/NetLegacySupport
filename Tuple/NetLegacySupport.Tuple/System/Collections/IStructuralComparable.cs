// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET20 || NET35

using System;

namespace System.Collections {

    public interface IStructuralComparable {
        Int32 CompareTo(Object other, IComparer comparer);
    }
}

#endif
