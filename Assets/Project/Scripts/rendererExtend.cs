using UnityEngine;
using System.Collections;

public static class rendererExtend {

	//avaliar o que a camera consegue ver
	public static bool isVisibleFrom(this Renderer renderer, Camera camera)
	{
		Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);

		return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
	}
}
