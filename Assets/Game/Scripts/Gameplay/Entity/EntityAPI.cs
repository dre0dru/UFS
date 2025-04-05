/**
* Code generation. Don't modify! 
**/

using Atomic.Entities;
using System.Runtime.CompilerServices;
using UnityEngine;
using Atomic.Entities;
using Atomic.Elements;
using Modules.Gameplay;

namespace Game.Gameplay
{
	public static class EntityAPI
	{
		///Tags
		public const int Player = -1615495341;
		public const int Enemy = 979269037;
		public const int Resource = 1172805184;
		public const int Damageable = 563499515;
		public const int Melee = 237393061;
		public const int Ranged = -1864224364;
		public const int Projectile = 1940275645;
		public const int PickUppable = 1776310196;


		///Values
		public const int Transform = -180157682; // Transform
		public const int Health = -915003867; // Health
		public const int DamageTakenEvent = -647889767; // IEvent<TakeDamageArgs>
		public const int DeathTakenEvent = 542106238; // IEvent<TakeDamageArgs>
		public const int AudioSource = 907064781; // AudioSource
		public const int Animator = -1714818978; // Animator
		public const int AnimationEventReceiver = 1837262450; // AnimationEventReceiver
		public const int AnimationTransform = -1692172885; // Transform
		public const int AimingDirection = 290970155; // IVariable<Vector2>
		public const int MovementDirection = 1140346022; // IVariable<Vector2>
		public const int MovementSpeed = -124615418; // IValue<float>
		public const int MovementCondition = -1067182762; // IExpression<bool>
		public const int RotationSpeed = 1771316350; // IValue<float>
		public const int RotationCondition = 1728556582; // IExpression<bool>
		public const int AttackCondition = -1481262935; // IExpression<bool>
		public const int AttackEvent = -691201150; // IEvent
		public const int AttackAction = 203766724; // IAction
		public const int Weapon = 1855955664; // IEntity
		public const int Damage = 375673178; // IValue<int>
		public const int FirePoint = 397255013; // Transform
		public const int SpreadAngle = -2096472624; // IValue<float>
		public const int AttackCooldown = 1736948685; // Cooldown
		public const int Ammo = 1337839892; // Ammo
		public const int ProjectilePrefab = 1557533000; // SceneEntity
		public const int AttackTarget = 226924714; // IVariable<IEntity>
		public const int AttackDistance = -1518989931; // IValue<float>
		public const int RaycastLayer = -415792016; // IValue<LayerMask>
		public const int Lifetime = -997109026; // Cooldown
		public const int DestroyAction = 85938956; // IAction
		public const int CollisionReceiver = 905037854; // CollisionEventReceiver
		public const int TriggerReceiver = 1006843418; // TriggerEventReceiver
		public const int PickupCondition = 824872013; // IExpression<IEntity, bool>
		public const int PickupItemAction = 130789355; // IAction<IEntity>
		public const int PickupItemEvent = -477751987; // IEvent


		///Tag Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPlayerTag(this IEntity obj) => obj.HasTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPlayerTag(this IEntity obj) => obj.AddTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPlayerTag(this IEntity obj) => obj.DelTag(Player);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasEnemyTag(this IEntity obj) => obj.HasTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddEnemyTag(this IEntity obj) => obj.AddTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelEnemyTag(this IEntity obj) => obj.DelTag(Enemy);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasResourceTag(this IEntity obj) => obj.HasTag(Resource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddResourceTag(this IEntity obj) => obj.AddTag(Resource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelResourceTag(this IEntity obj) => obj.DelTag(Resource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageableTag(this IEntity obj) => obj.HasTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageableTag(this IEntity obj) => obj.AddTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageableTag(this IEntity obj) => obj.DelTag(Damageable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMeleeTag(this IEntity obj) => obj.HasTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMeleeTag(this IEntity obj) => obj.AddTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMeleeTag(this IEntity obj) => obj.DelTag(Melee);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRangedTag(this IEntity obj) => obj.HasTag(Ranged);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRangedTag(this IEntity obj) => obj.AddTag(Ranged);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRangedTag(this IEntity obj) => obj.DelTag(Ranged);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectileTag(this IEntity obj) => obj.HasTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectileTag(this IEntity obj) => obj.AddTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectileTag(this IEntity obj) => obj.DelTag(Projectile);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickUppableTag(this IEntity obj) => obj.HasTag(PickUppable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPickUppableTag(this IEntity obj) => obj.AddTag(PickUppable);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickUppableTag(this IEntity obj) => obj.DelTag(PickUppable);


		///Value Extensions

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetTransform(this IEntity obj) => obj.GetValue<Transform>(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTransform(this IEntity obj, out Transform value) => obj.TryGetValue(Transform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTransform(this IEntity obj, Transform value) => obj.AddValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTransform(this IEntity obj) => obj.HasValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTransform(this IEntity obj) => obj.DelValue(Transform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTransform(this IEntity obj, Transform value) => obj.SetValue(Transform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Health GetHealth(this IEntity obj) => obj.GetValue<Health>(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetHealth(this IEntity obj, out Health value) => obj.TryGetValue(Health, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddHealth(this IEntity obj, Health value) => obj.AddValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasHealth(this IEntity obj) => obj.HasValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelHealth(this IEntity obj) => obj.DelValue(Health);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetHealth(this IEntity obj, Health value) => obj.SetValue(Health, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<TakeDamageArgs> GetDamageTakenEvent(this IEntity obj) => obj.GetValue<IEvent<TakeDamageArgs>>(DamageTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamageTakenEvent(this IEntity obj, out IEvent<TakeDamageArgs> value) => obj.TryGetValue(DamageTakenEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamageTakenEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.AddValue(DamageTakenEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamageTakenEvent(this IEntity obj) => obj.HasValue(DamageTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamageTakenEvent(this IEntity obj) => obj.DelValue(DamageTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamageTakenEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.SetValue(DamageTakenEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent<TakeDamageArgs> GetDeathTakenEvent(this IEntity obj) => obj.GetValue<IEvent<TakeDamageArgs>>(DeathTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDeathTakenEvent(this IEntity obj, out IEvent<TakeDamageArgs> value) => obj.TryGetValue(DeathTakenEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDeathTakenEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.AddValue(DeathTakenEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDeathTakenEvent(this IEntity obj) => obj.HasValue(DeathTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDeathTakenEvent(this IEntity obj) => obj.DelValue(DeathTakenEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDeathTakenEvent(this IEntity obj, IEvent<TakeDamageArgs> value) => obj.SetValue(DeathTakenEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AudioSource GetAudioSource(this IEntity obj) => obj.GetValue<AudioSource>(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAudioSource(this IEntity obj, out AudioSource value) => obj.TryGetValue(AudioSource, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAudioSource(this IEntity obj, AudioSource value) => obj.AddValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAudioSource(this IEntity obj) => obj.HasValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAudioSource(this IEntity obj) => obj.DelValue(AudioSource);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAudioSource(this IEntity obj, AudioSource value) => obj.SetValue(AudioSource, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Animator GetAnimator(this IEntity obj) => obj.GetValue<Animator>(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimator(this IEntity obj, out Animator value) => obj.TryGetValue(Animator, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimator(this IEntity obj, Animator value) => obj.AddValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimator(this IEntity obj) => obj.HasValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimator(this IEntity obj) => obj.DelValue(Animator);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimator(this IEntity obj, Animator value) => obj.SetValue(Animator, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static AnimationEventReceiver GetAnimationEventReceiver(this IEntity obj) => obj.GetValue<AnimationEventReceiver>(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationEventReceiver(this IEntity obj, out AnimationEventReceiver value) => obj.TryGetValue(AnimationEventReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.AddValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationEventReceiver(this IEntity obj) => obj.HasValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationEventReceiver(this IEntity obj) => obj.DelValue(AnimationEventReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationEventReceiver(this IEntity obj, AnimationEventReceiver value) => obj.SetValue(AnimationEventReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetAnimationTransform(this IEntity obj) => obj.GetValue<Transform>(AnimationTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAnimationTransform(this IEntity obj, out Transform value) => obj.TryGetValue(AnimationTransform, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAnimationTransform(this IEntity obj, Transform value) => obj.AddValue(AnimationTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAnimationTransform(this IEntity obj) => obj.HasValue(AnimationTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAnimationTransform(this IEntity obj) => obj.DelValue(AnimationTransform);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAnimationTransform(this IEntity obj, Transform value) => obj.SetValue(AnimationTransform, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector2> GetAimingDirection(this IEntity obj) => obj.GetValue<IVariable<Vector2>>(AimingDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAimingDirection(this IEntity obj, out IVariable<Vector2> value) => obj.TryGetValue(AimingDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAimingDirection(this IEntity obj, IVariable<Vector2> value) => obj.AddValue(AimingDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAimingDirection(this IEntity obj) => obj.HasValue(AimingDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAimingDirection(this IEntity obj) => obj.DelValue(AimingDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAimingDirection(this IEntity obj, IVariable<Vector2> value) => obj.SetValue(AimingDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<Vector2> GetMovementDirection(this IEntity obj) => obj.GetValue<IVariable<Vector2>>(MovementDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMovementDirection(this IEntity obj, out IVariable<Vector2> value) => obj.TryGetValue(MovementDirection, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMovementDirection(this IEntity obj, IVariable<Vector2> value) => obj.AddValue(MovementDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovementDirection(this IEntity obj) => obj.HasValue(MovementDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovementDirection(this IEntity obj) => obj.DelValue(MovementDirection);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMovementDirection(this IEntity obj, IVariable<Vector2> value) => obj.SetValue(MovementDirection, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetMovementSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(MovementSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMovementSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(MovementSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMovementSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(MovementSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovementSpeed(this IEntity obj) => obj.HasValue(MovementSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovementSpeed(this IEntity obj) => obj.DelValue(MovementSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMovementSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(MovementSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetMovementCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(MovementCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetMovementCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(MovementCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddMovementCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(MovementCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasMovementCondition(this IEntity obj) => obj.HasValue(MovementCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelMovementCondition(this IEntity obj) => obj.DelValue(MovementCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetMovementCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(MovementCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetRotationSpeed(this IEntity obj) => obj.GetValue<IValue<float>>(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationSpeed(this IEntity obj, out IValue<float> value) => obj.TryGetValue(RotationSpeed, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotationSpeed(this IEntity obj, IValue<float> value) => obj.AddValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationSpeed(this IEntity obj) => obj.HasValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationSpeed(this IEntity obj) => obj.DelValue(RotationSpeed);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationSpeed(this IEntity obj, IValue<float> value) => obj.SetValue(RotationSpeed, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetRotationCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(RotationCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRotationCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(RotationCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRotationCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(RotationCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRotationCondition(this IEntity obj) => obj.HasValue(RotationCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRotationCondition(this IEntity obj) => obj.DelValue(RotationCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRotationCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(RotationCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<bool> GetAttackCondition(this IEntity obj) => obj.GetValue<IExpression<bool>>(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackCondition(this IEntity obj, out IExpression<bool> value) => obj.TryGetValue(AttackCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackCondition(this IEntity obj, IExpression<bool> value) => obj.AddValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackCondition(this IEntity obj) => obj.HasValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackCondition(this IEntity obj) => obj.DelValue(AttackCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackCondition(this IEntity obj, IExpression<bool> value) => obj.SetValue(AttackCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetAttackEvent(this IEntity obj) => obj.GetValue<IEvent>(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(AttackEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackEvent(this IEntity obj, IEvent value) => obj.AddValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackEvent(this IEntity obj) => obj.HasValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackEvent(this IEntity obj) => obj.DelValue(AttackEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackEvent(this IEntity obj, IEvent value) => obj.SetValue(AttackEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetAttackAction(this IEntity obj) => obj.GetValue<IAction>(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackAction(this IEntity obj, out IAction value) => obj.TryGetValue(AttackAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackAction(this IEntity obj, IAction value) => obj.AddValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackAction(this IEntity obj) => obj.HasValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackAction(this IEntity obj) => obj.DelValue(AttackAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackAction(this IEntity obj, IAction value) => obj.SetValue(AttackAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEntity GetWeapon(this IEntity obj) => obj.GetValue<IEntity>(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetWeapon(this IEntity obj, out IEntity value) => obj.TryGetValue(Weapon, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddWeapon(this IEntity obj, IEntity value) => obj.AddValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasWeapon(this IEntity obj) => obj.HasValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelWeapon(this IEntity obj) => obj.DelValue(Weapon);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetWeapon(this IEntity obj, IEntity value) => obj.SetValue(Weapon, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<int> GetDamage(this IEntity obj) => obj.GetValue<IValue<int>>(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDamage(this IEntity obj, out IValue<int> value) => obj.TryGetValue(Damage, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDamage(this IEntity obj, IValue<int> value) => obj.AddValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDamage(this IEntity obj) => obj.HasValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDamage(this IEntity obj) => obj.DelValue(Damage);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDamage(this IEntity obj, IValue<int> value) => obj.SetValue(Damage, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Transform GetFirePoint(this IEntity obj) => obj.GetValue<Transform>(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetFirePoint(this IEntity obj, out Transform value) => obj.TryGetValue(FirePoint, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddFirePoint(this IEntity obj, Transform value) => obj.AddValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasFirePoint(this IEntity obj) => obj.HasValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelFirePoint(this IEntity obj) => obj.DelValue(FirePoint);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetFirePoint(this IEntity obj, Transform value) => obj.SetValue(FirePoint, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetSpreadAngle(this IEntity obj) => obj.GetValue<IValue<float>>(SpreadAngle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetSpreadAngle(this IEntity obj, out IValue<float> value) => obj.TryGetValue(SpreadAngle, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddSpreadAngle(this IEntity obj, IValue<float> value) => obj.AddValue(SpreadAngle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasSpreadAngle(this IEntity obj) => obj.HasValue(SpreadAngle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelSpreadAngle(this IEntity obj) => obj.DelValue(SpreadAngle);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetSpreadAngle(this IEntity obj, IValue<float> value) => obj.SetValue(SpreadAngle, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetAttackCooldown(this IEntity obj) => obj.GetValue<Cooldown>(AttackCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackCooldown(this IEntity obj, out Cooldown value) => obj.TryGetValue(AttackCooldown, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackCooldown(this IEntity obj, Cooldown value) => obj.AddValue(AttackCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackCooldown(this IEntity obj) => obj.HasValue(AttackCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackCooldown(this IEntity obj) => obj.DelValue(AttackCooldown);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackCooldown(this IEntity obj, Cooldown value) => obj.SetValue(AttackCooldown, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Ammo GetAmmo(this IEntity obj) => obj.GetValue<Ammo>(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAmmo(this IEntity obj, out Ammo value) => obj.TryGetValue(Ammo, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAmmo(this IEntity obj, Ammo value) => obj.AddValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAmmo(this IEntity obj) => obj.HasValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAmmo(this IEntity obj) => obj.DelValue(Ammo);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAmmo(this IEntity obj, Ammo value) => obj.SetValue(Ammo, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static SceneEntity GetProjectilePrefab(this IEntity obj) => obj.GetValue<SceneEntity>(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetProjectilePrefab(this IEntity obj, out SceneEntity value) => obj.TryGetValue(ProjectilePrefab, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddProjectilePrefab(this IEntity obj, SceneEntity value) => obj.AddValue(ProjectilePrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasProjectilePrefab(this IEntity obj) => obj.HasValue(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelProjectilePrefab(this IEntity obj) => obj.DelValue(ProjectilePrefab);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetProjectilePrefab(this IEntity obj, SceneEntity value) => obj.SetValue(ProjectilePrefab, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IVariable<IEntity> GetAttackTarget(this IEntity obj) => obj.GetValue<IVariable<IEntity>>(AttackTarget);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackTarget(this IEntity obj, out IVariable<IEntity> value) => obj.TryGetValue(AttackTarget, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackTarget(this IEntity obj, IVariable<IEntity> value) => obj.AddValue(AttackTarget, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackTarget(this IEntity obj) => obj.HasValue(AttackTarget);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackTarget(this IEntity obj) => obj.DelValue(AttackTarget);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackTarget(this IEntity obj, IVariable<IEntity> value) => obj.SetValue(AttackTarget, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<float> GetAttackDistance(this IEntity obj) => obj.GetValue<IValue<float>>(AttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetAttackDistance(this IEntity obj, out IValue<float> value) => obj.TryGetValue(AttackDistance, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddAttackDistance(this IEntity obj, IValue<float> value) => obj.AddValue(AttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasAttackDistance(this IEntity obj) => obj.HasValue(AttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelAttackDistance(this IEntity obj) => obj.DelValue(AttackDistance);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetAttackDistance(this IEntity obj, IValue<float> value) => obj.SetValue(AttackDistance, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IValue<LayerMask> GetRaycastLayer(this IEntity obj) => obj.GetValue<IValue<LayerMask>>(RaycastLayer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetRaycastLayer(this IEntity obj, out IValue<LayerMask> value) => obj.TryGetValue(RaycastLayer, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddRaycastLayer(this IEntity obj, IValue<LayerMask> value) => obj.AddValue(RaycastLayer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasRaycastLayer(this IEntity obj) => obj.HasValue(RaycastLayer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelRaycastLayer(this IEntity obj) => obj.DelValue(RaycastLayer);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetRaycastLayer(this IEntity obj, IValue<LayerMask> value) => obj.SetValue(RaycastLayer, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Cooldown GetLifetime(this IEntity obj) => obj.GetValue<Cooldown>(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLifetime(this IEntity obj, out Cooldown value) => obj.TryGetValue(Lifetime, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddLifetime(this IEntity obj, Cooldown value) => obj.AddValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasLifetime(this IEntity obj) => obj.HasValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelLifetime(this IEntity obj) => obj.DelValue(Lifetime);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetLifetime(this IEntity obj, Cooldown value) => obj.SetValue(Lifetime, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction GetDestroyAction(this IEntity obj) => obj.GetValue<IAction>(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetDestroyAction(this IEntity obj, out IAction value) => obj.TryGetValue(DestroyAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddDestroyAction(this IEntity obj, IAction value) => obj.AddValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasDestroyAction(this IEntity obj) => obj.HasValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelDestroyAction(this IEntity obj) => obj.DelValue(DestroyAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetDestroyAction(this IEntity obj, IAction value) => obj.SetValue(DestroyAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static CollisionEventReceiver GetCollisionReceiver(this IEntity obj) => obj.GetValue<CollisionEventReceiver>(CollisionReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetCollisionReceiver(this IEntity obj, out CollisionEventReceiver value) => obj.TryGetValue(CollisionReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddCollisionReceiver(this IEntity obj, CollisionEventReceiver value) => obj.AddValue(CollisionReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasCollisionReceiver(this IEntity obj) => obj.HasValue(CollisionReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelCollisionReceiver(this IEntity obj) => obj.DelValue(CollisionReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetCollisionReceiver(this IEntity obj, CollisionEventReceiver value) => obj.SetValue(CollisionReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static TriggerEventReceiver GetTriggerReceiver(this IEntity obj) => obj.GetValue<TriggerEventReceiver>(TriggerReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetTriggerReceiver(this IEntity obj, out TriggerEventReceiver value) => obj.TryGetValue(TriggerReceiver, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddTriggerReceiver(this IEntity obj, TriggerEventReceiver value) => obj.AddValue(TriggerReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasTriggerReceiver(this IEntity obj) => obj.HasValue(TriggerReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelTriggerReceiver(this IEntity obj) => obj.DelValue(TriggerReceiver);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetTriggerReceiver(this IEntity obj, TriggerEventReceiver value) => obj.SetValue(TriggerReceiver, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IExpression<IEntity, bool> GetPickupCondition(this IEntity obj) => obj.GetValue<IExpression<IEntity, bool>>(PickupCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickupCondition(this IEntity obj, out IExpression<IEntity, bool> value) => obj.TryGetValue(PickupCondition, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPickupCondition(this IEntity obj, IExpression<IEntity, bool> value) => obj.AddValue(PickupCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickupCondition(this IEntity obj) => obj.HasValue(PickupCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickupCondition(this IEntity obj) => obj.DelValue(PickupCondition);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickupCondition(this IEntity obj, IExpression<IEntity, bool> value) => obj.SetValue(PickupCondition, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IAction<IEntity> GetPickupItemAction(this IEntity obj) => obj.GetValue<IAction<IEntity>>(PickupItemAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickupItemAction(this IEntity obj, out IAction<IEntity> value) => obj.TryGetValue(PickupItemAction, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPickupItemAction(this IEntity obj, IAction<IEntity> value) => obj.AddValue(PickupItemAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickupItemAction(this IEntity obj) => obj.HasValue(PickupItemAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickupItemAction(this IEntity obj) => obj.DelValue(PickupItemAction);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickupItemAction(this IEntity obj, IAction<IEntity> value) => obj.SetValue(PickupItemAction, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static IEvent GetPickupItemEvent(this IEntity obj) => obj.GetValue<IEvent>(PickupItemEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetPickupItemEvent(this IEntity obj, out IEvent value) => obj.TryGetValue(PickupItemEvent, out value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool AddPickupItemEvent(this IEntity obj, IEvent value) => obj.AddValue(PickupItemEvent, value);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool HasPickupItemEvent(this IEntity obj) => obj.HasValue(PickupItemEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool DelPickupItemEvent(this IEntity obj) => obj.DelValue(PickupItemEvent);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void SetPickupItemEvent(this IEntity obj, IEvent value) => obj.SetValue(PickupItemEvent, value);
    }
}
