#region Copyright (C) 2007-2008 Team MediaPortal

/*
    Copyright (C) 2007-2008 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal II

    MediaPortal II is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal II is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal II.  If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;

namespace MediaPortal.Core.Exceptions
{
  /// <summary>
  /// Fatal exception, will be thrown if something happened what must not happen. The reason
  /// of this exception is always a coding problem.
  /// </summary>
  public class FatalException : ApplicationException
  {
    public FatalException(string msg, params object[] args):
        base(string.Format(msg, args)) { }
    public FatalException(string msg, Exception ex, params object[] args):
        base(string.Format(msg, args), ex) { }
  }

  /// <summary>
  /// Thrown if a module or instance is in an invalid state for the current operation.
  /// </summary>
  public class InvalidStateException : ApplicationException
  {
    public InvalidStateException(string msg, params object[] args):
        base(string.Format(msg, args)) { }
    public InvalidStateException(string msg, Exception ex, params object[] args):
        base(string.Format(msg, args), ex) { }
  }
}
