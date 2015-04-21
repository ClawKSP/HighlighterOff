/*
 * This module written by Claw. For more details, please visit
 * http://forum.kerbalspaceprogram.com/threads/97285
 * 
 * This mod is covered under the CC-BY-NC-SA license. See the license.txt for more details.
 * (https://creativecommons.org/licenses/by-nc-sa/4.0/)
 * 
 *
 * HighlighterOff - Written for KSP v0.90.0
 * 
 * - Disables highlighting for parts in flight mode.
 * 
 * Change Log:
 * - v01.00    Initial Release
 * 
 */

using UnityEngine;
using KSP;


namespace ClawKSP
{
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class HighlighterOff : MonoBehaviour
    {
        public void Start ()
        {
            Debug.LogWarning("HighlighterOff.Start(): version 1.0");
            GameEvents.onVesselGoOffRails.Add(OffRails);
        }

        public void OffRails (Vessel vesselToFix)
        {
            Debug.Log("HighlighterOff.OffRails(): Disabling Highlight");

            for (int indexParts = 0; indexParts < vesselToFix.Parts.Count; indexParts++)
            {
                vesselToFix.Parts[indexParts].highlightType = Part.HighlightType.Disabled;
            }
        }

        public void OnDestroy ()
        {
            Debug.Log("HighlighterOff.OnDestroy()");
            GameEvents.onVesselGoOffRails.Remove(OffRails);
        }
    }
}
