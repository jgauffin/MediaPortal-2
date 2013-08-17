#region Copyright (C) 2007-2013 Team MediaPortal

/*
    Copyright (C) 2007-2013 Team MediaPortal
    http://www.team-mediaportal.com

    This file is part of MediaPortal 2

    MediaPortal 2 is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    MediaPortal 2 is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with MediaPortal 2. If not, see <http://www.gnu.org/licenses/>.
*/

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using MediaPortal.UiComponents.Media.Models.ScreenData;
using MediaPortal.UiComponents.Media.Settings;

namespace MediaPortal.UiComponents.Media.Models.NavigationModel
{
  /// <summary>
  /// Base class for navigation configuratio classes. Derived classes need to fill the dictionaries <see cref="_navigationTree"/> and <see cref="_layoutTypes"/>
  /// to configure the possible transitions between screens. If no matching combination is found, the regular algorithm will be used (taking next screen of remaining
  /// list).
  /// </summary>
  public class BaseNavigation : IMediaNavigationConfig
  {
    protected ICollection<AbstractScreenData> _availableScreens;
    protected Dictionary<Type, Type> _navigationTree = new Dictionary<Type, Type>();
    protected Dictionary<Type, LayoutType> _layoutTypes = new Dictionary<Type, LayoutType>();

    public bool GetNextScreenData(AbstractScreenData currentScreen, IEnumerable<AbstractScreenData> availableScreens, out AbstractScreenData nextScreenData)
    {
      Type nextScreenType;
      if (_navigationTree.TryGetValue(currentScreen.GetType(), out nextScreenType))
      {
        nextScreenData = availableScreens.FirstOrDefault(screen => screen.GetType() == nextScreenType);
        if (nextScreenData != null)
          return true;
      }
      nextScreenData = null;
      return false;
    }

    public bool GetLayoutType(AbstractScreenData currentScreen, out LayoutType layoutType)
    {
      return _layoutTypes.TryGetValue(currentScreen.GetType(), out layoutType);
    }
  }
}
