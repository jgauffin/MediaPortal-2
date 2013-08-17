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
using MediaPortal.UiComponents.Media.Models.ScreenData;
using MediaPortal.UiComponents.Media.Settings;

namespace MediaPortal.UiComponents.Media.Models.NavigationModel
{
  /// <summary>
  /// Initialization interface for the <see cref="MediaNavigationModel"/>.
  /// </summary>
  public interface IMediaNavigationInitializer
  {
    /// <summary>
    /// Gets the <see cref="MediaNavigationMode"/> associated to this class.
    /// </summary>
    string MediaNavigationMode { get; }
    
    /// <summary>
    /// Gets the navigation root state.
    /// </summary>
    Guid MediaNavigationRootState { get; }

    /// <summary>
    /// Initializes the media navigation, returns the required <see cref="NavigationData"/>.
    /// </summary>
    /// <param name="mediaNavigationMode">MediaNavigationMode</param>
    /// <param name="navigationData">NavigationData</param>
    void InitMediaNavigation(out string mediaNavigationMode, out NavigationData navigationData);
  }

  /// <summary>
  /// <see cref="IMediaNavigationConfig"/> provides information about screens and layout types for the media navigation.
  /// </summary>
  public interface IMediaNavigationConfig
  {
    /// <summary>
    /// Gets the preferred <paramref name="nextScreenData"/> for the current given <paramref name="currentScreen"/> out of the <paramref name="availableScreens"/>.
    /// </summary>
    /// <param name="currentScreen">Current screen.</param>
    /// <param name="availableScreens">List of remaining valid screens.</param>
    /// <param name="nextScreenData">Outputs the next preferred screen.</param>
    /// <returns><c>true</c> if successful.</returns>
    bool GetNextScreenData(AbstractScreenData currentScreen, IEnumerable<AbstractScreenData> availableScreens, out AbstractScreenData nextScreenData);

    /// <summary>
    /// Gets the preferred <paramref name="layoutType"/> for the given <paramref name="currentScreen"/>.
    /// </summary>
    /// <param name="currentScreen">Current screen.</param>
    /// <param name="layoutType">Outputs the preferred layout type.</param>
    /// <returns><c>true</c> if successful.</returns>
    bool GetLayoutType(AbstractScreenData currentScreen, out LayoutType layoutType);
  }
}
