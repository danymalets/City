using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class JointExtensions
    {
        public static void SetLimit(this ConfigurableJoint joint, float limit)
        {
            SoftJointLimit jointLinearLimit = joint.linearLimit;
            jointLinearLimit.limit = limit;
            joint.linearLimit = jointLinearLimit;
        }
        
        public static void SetSpring(this ConfigurableJoint joint, float spring)
        {
            SoftJointLimitSpring limitSpring = joint.linearLimitSpring;
            limitSpring.spring = spring;
            joint.linearLimitSpring = limitSpring;
        }
    }
}