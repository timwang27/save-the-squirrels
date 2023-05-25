/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.OpenXR.Input;

/**
 * Spawns a <see cref="CarBehaviour"/> when a plane is tapped.
 */
public class SquirrelManager : MonoBehaviour
{
    public GameObject SquirrelPrefab;
    public ReticleBehaviour Reticle;
    public PlaneSurfaceManager PlaneSurfaceManager;
    public GameObject wallPrefab;
    // public ARPlane CurrentPlane;

    public PlayerTouchMovement Squirrel;

    private void Update()
    {
        if (Squirrel == null && WasTapped() && Reticle.CurrentPlane != null)
        {
            // Spawn our squirrel and walls at the reticle location.
            var wall = Instantiate(wallPrefab);
            wall.transform.position = Reticle.transform.position; // new Vector3(Reticle.transform.position.x, Reticle.transform.position.y, Reticle.transform.position.z);
            var obj = GameObject.Instantiate(SquirrelPrefab);
            Squirrel = obj.GetComponent<PlayerTouchMovement>();
            Squirrel.transform.position = Reticle.transform.position;
            PlaneSurfaceManager.LockPlane(Reticle.CurrentPlane);
            // Start timer
            CarTimeManager.timerOn = true;
        }
    }

    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }

    public void ResetSquirrel()
    {
        var screenCenter = Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        GameObject squirrel = GameObject.FindWithTag("Player");
        ARRaycastManager aRRaycast = GameObject.FindWithTag("Raycast Manager").GetComponent<ARRaycastManager>();
        // PlaneSurfaceManager.RaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds);
        if (aRRaycast.Raycast(screenCenter, hits, TrackableType.PlaneWithinBounds))
        {
            foreach(ARRaycastHit hit in hits)
            {
                UnityEngine.Pose pose = hit.pose;
                squirrel.transform.position = pose.position;
            }
        } 
    }
}
